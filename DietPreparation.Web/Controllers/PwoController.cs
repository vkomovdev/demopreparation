using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Requests.PWOs;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Requests.PWOs;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.PWOs;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Utilities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers
{
	public class PwoController : Controller
	{
		private readonly ViewRenderer _viewRenderer;
		private readonly IMediator _mediator;
		private readonly IMapper _mapper;
		private readonly IAuthContextAccessor _authContextAccessor;

		public PwoController(ViewRenderer viewRenderer, IMediator mediator, IMapper mapper, IAuthContextAccessor authContextAccessor)
		{
			_viewRenderer = viewRenderer;
			_mediator = mediator;
			_mapper = mapper;
			_authContextAccessor = authContextAccessor;
		}

		[HttpGet("/pwo/details/{requestId:int}/{sequence:int}")]
		[Authorize(Permissions.ProcessWorkOrders.View)]
		public async Task<IActionResult> Details(int requestId, int sequence)
		{
			var pwoDetail = await _mediator.Send(new GetPwoDetailQueryRequest() { RequestId = requestId, Sequence = sequence });

			return View(_mapper.Map<PwoDetailViewModel>(pwoDetail));
		}

		[HttpGet("/pwo/close-details/{requestId:int}/{sequence:int}")]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public async Task<IActionResult> CloseDetails(int requestId, int sequence)
		{
			var response = await _mediator.Send(new GetPwoDetailQueryRequest() { RequestId = requestId, Sequence = sequence });

			if (!string.IsNullOrEmpty(response.Header.PwoDto.CompletedBy))
			{
				return RedirectToAction("Details", new { requestId, sequence });
			}
			return View(_mapper.Map<PwoDetailViewModel>(response));
		}

		[HttpPost("/pwo/close-details/{requestId:int}/{sequence:int}")]
		[ValidateAntiForgeryToken]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public async Task<IActionResult> CloseDetails(PwoCloseViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("CloseDetails", new { requestId = model.RequestId, sequence = model.Sequence });
			}

			var command = _mapper.Map<PwoCloseRequest>(model);
			var response = await _mediator.Send(command);

			if (response.Exception is not null)
			{
				//TODO Exception
				throw new Exception(response.Exception.Message);
			}

			return RedirectToAction("Details", new { requestId = model.RequestId, sequence = model.Sequence });
		}

		[HttpGet]
		[Authorize(Permissions.Batches.View)]
		public async Task<IActionResult> BatchDetails(int requestId)
		{
			var response = await _mediator.Send(new GetBatchQueryRequest() { RequestId = requestId });
			return View(_mapper.Map<PwoBatchViewModel>(response));
		}

		[HttpPost]
		[AxiosExceptionHandle]
		[Authorize(Permissions.Batches.View)]
		public async Task<IActionResult> BatchDetails([FromBody] PwoBatchViewModel model)
		{
			var command = _mapper.Map<CreateBatchRequest>(model);

			command.Operator = _authContextAccessor.UserName[1..].Split('\\')[^1].ToUpper();

			var response = await _mediator.Send(command);
			if (response.Exception is not null)
			{
				throw new Exception(response.Exception.Message);
			}
			return Ok();
		}

		[HttpGet]
		[Authorize(Permissions.Batches.View)]
		public async Task<IActionResult> BatchList(int requestId)
		{
			var request = new GetBatchesQueryRequest { RequestId = requestId, Type = BatchType.All };
			var response = await _mediator.Send(request);

			if (response.Batches is null)
			{
				return RedirectToAction("BatchDetails", new { requestId });
			}

			var model = _mapper.Map<PwoBatchListViewModel>(response);

			return View(model);
		}

		[HttpGet]
		[Authorize(Permissions.ProcessWorkOrders.View)]
		public IActionResult Search([FromQuery] PwoFilterOptions prefilter)
		{
			// TODO: change to class in query
			var model = new PwoSearchViewModel();
			model.PreFilter = prefilter.GetDisplayName();
			return View(model);
		}

		[HttpGet("/pwo/search-pwos-list")]
		[Authorize(Permissions.ProcessWorkOrders.View)]
		public async Task<IActionResult> SearchPwosList([FromQuery] TableOptionsViewModel tableOptions)
		{
			var request = _mapper.Map<GetDietRequestSearchQueryRequest>(tableOptions);

			if (request.FilterBy is not null)
			{
				if (!string.IsNullOrEmpty(request.FilterBy.LotId) && string.IsNullOrEmpty(request.FilterBy.LotYear))
				{
					return RedirectToAction("SearchPwosList");
				}
			}

			var response = await _mediator.Send(request);

			if (response.Exception is not null)
			{
				throw new Exception(response.Exception.Message);
			}

			return Ok(_mapper.Map<PwoSearchViewModel>(response));
		}

		[HttpGet]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public IActionResult Create()
		{
			return View();
		}

		[HttpGet("/pwo/create-pwos-list")]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public async Task<IActionResult> CreatePwosList([FromQuery] TableOptionsViewModel tableOptions)
		{
			var response = await _mediator.Send(_mapper.Map<GetDietRequestCreateQueryRequest>(tableOptions));
			return Ok(_mapper.Map<PwoSearchViewModel>(response));
		}

		[HttpGet]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public IActionResult Close()
		{
			return View();
		}

		[HttpGet("/pwo/close-pwos-list")]
		[Authorize(Permissions.ProcessWorkOrders.Create)]
		public async Task<IActionResult> ClosePwosList([FromQuery] TableOptionsViewModel tableOptions)
		{
			var response = await _mediator.Send(_mapper.Map<GetDietRequestCloseQueryRequest>(tableOptions));
			return Ok(_mapper.Map<PwoSearchViewModel>(response));
		}

		[HttpGet]
		[AxiosExceptionHandle]
		public async Task<IActionResult> Print([FromQuery] int? requestId, int? sequence)
		{
			if (requestId is null || sequence is null)
			{
				throw new DietPreparationException(CommonErrorCode.ParametersNullException);
			}

			var request = new GetPwoDetailQueryRequest { RequestId = requestId.Value, Sequence = sequence.Value };
			var response = await _mediator.Send(request);

			if (response.Exception is not null)
			{
				throw new Exception(response.Exception.Message);
			}

			return await Print(_mapper.Map<PrintPwoBatchViewModel>(response));
		}

		public async Task<IActionResult> Print(PrintPwoBatchViewModel viewModel)
		{
			if (viewModel is null)
			{
				throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
			}

			var htmlContent = await _viewRenderer.RenderViewToString(ControllerContext, "Print", viewModel);
			return new OkObjectResult(new { printContent = htmlContent });
		}

		[HttpPost]
		[AxiosExceptionHandle]
		public async Task<IActionResult> PrintConfirm([FromBody] PrintPwoBatchConfirmViewModel viewModel)
		{
			if (viewModel is null)
			{
				throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
			}

			var request = new ConfirmPwoRequest { PwoId = viewModel.PwoId, Type = PwoConfirmType.Pwo };
			var response = await _mediator.Send(request);

			if (response.Exception is not null)
			{
				throw new Exception(response.Exception.Message);
			}

			return Ok();
		}
	}
}