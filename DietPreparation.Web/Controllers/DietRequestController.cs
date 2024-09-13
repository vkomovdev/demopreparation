using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.Metadata;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Utilities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class DietRequestController : Controller
{
	private readonly ViewRenderer _viewRenderer;
	private readonly IAuthContextAccessor _authContextAccessor;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public DietRequestController(ViewRenderer viewRenderer, IAuthContextAccessor authContextAccessor, IMediator mediator, IMapper mapper)
	{
		_viewRenderer = viewRenderer;
		_authContextAccessor = authContextAccessor;
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	[Authorize(Permissions.DietRequests.View)]
	public IActionResult Index()
	{
		return RedirectToAction(nameof(Search));
	}

	[HttpGet]
	[Authorize(Permissions.DietRequests.View)]
	public IActionResult Search([FromQuery] DietRequestFilterOptions prefilter)
	{
		// TODO: change to class in query
		var model = new DietRequestSearchViewModel();
		model.PreFilter = prefilter.GetDisplayName();
		return View(model);
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.View)]
	public async Task<IActionResult> DietRequestList([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetDietRequestsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
		}

		var model = _mapper.Map<DietRequestSearchViewModel>(response);
		return Ok(model);
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.DietRequests.Create)]
	public async Task<IActionResult> Create()
	{
		var metadata = await GetMetadata();
		var model = _mapper.Map<EditDietRequestViewModel>(metadata);

		return View(model);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.Create)]
	public async Task<IActionResult> Create([FromBody] EditDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateDietRequestWithAuditRequest>(viewModel);
		request.ChangeOperator = "TestUser";//TODO: Replace with actual user
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		if (viewModel.PrintAfterSave)
		{
			return await Print(_mapper.Map<PrintDietRequestViewModel>(response));
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> Edit(int? id)
	{
		if (id is null)
		{
			throw new DietPreparationException(CommonErrorCode.ParametersNullException);
		}

		var request = new GetDietRequestQueryRequest { Id = id };
		var response = await _mediator.Send(request);
		var metadata = await GetMetadata();

		var model = new EditDietRequestViewModel();
		_mapper.Map(response, model);
		_mapper.Map(metadata, model);

		return View(model);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> Edit([FromBody] EditDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<UpdateDietRequestWithAuditRequest>(viewModel);
		request.ChangeOperator = "TestUser";//TODO: Replace with actual user
		var response = await _mediator.Send<UpdateDietRequestResponse>(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		if (viewModel.PrintAfterSave)
		{
			return await Print(_mapper.Map<PrintDietRequestViewModel>(response));
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.Delete)]
	public async Task<IActionResult> Delete([FromBody] DeleteDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<DeleteDietRequestWithAuditRequest>(viewModel);
		request.ChangeOperator = "TestUser";//TODO: Replace with actual user
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	/// <summary>Restore deleted DietRequest</summary>
	[HttpPost]
	[AxiosExceptionHandle]
	[AxiosRedirectIfSuccess(Action = nameof(Search), Controller = nameof(DietRequestController))]
	[Authorize(Permissions.DietRequests.Activate)]
	public async Task<IActionResult> Activate([FromBody] ActivateDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<ActivateDietRequestRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.DietRequests.View)]
	public async Task<IActionResult> Details(int? id)
	{
		if (id is null)
		{
			throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
		}

		var request = new GetDietRequestQueryRequest { Id = id };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var model = _mapper.Map<ReadDietRequestViewModel>(response);
		return View(model);
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.DietRequests.Create)]
	public async Task<IActionResult> CloneDetails(int? id)
	{
		if (id is null)
		{
			throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
		}

		var request = new GetDietRequestQueryRequest { Id = id };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var model = _mapper.Map<ReadDietRequestViewModel>(response);
		return View(model);
	}

	[HttpPost]
	[ExceptionHandle]
	[Authorize(Permissions.DietRequests.Create)]
	public async Task<IActionResult> Clone(CloneDietRequestViewModel viewModel)
	{
		var request = _mapper.Map<CloneDietRequestRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var metadata = await GetMetadata();
		var model = new EditDietRequestViewModel();
		_mapper.Map(response, model);
		_mapper.Map(metadata, model);

		return View(model);
	}

	[HttpGet]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> UpdateRequests()
	{
		var usedMedicatedPremixes = await _mediator.Send(new GetUsedMedicatedPremixesQueryRequest());
		var notUsedMedicatedPremixes = await _mediator.Send(new GetNotUsedMedicatedPremixesQueryRequest());
		var clonedDietRequests = await _mediator.Send(new GetClonedDietRequestsQueryRequest());
		var notClonedDietRequests = await _mediator.Send(new GetNotClonedDietRequestsQueryRequest());

		var model = new UpdateDietRequestsViewModel();
		_mapper.Map(usedMedicatedPremixes, model);
		_mapper.Map(notUsedMedicatedPremixes, model);
		_mapper.Map(clonedDietRequests, model);
		_mapper.Map(notClonedDietRequests, model);

		return View(model);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[AxiosRedirectIfSuccess(Action = nameof(UpdateRequests), Controller = nameof(DietRequestController))]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> MarkPremixAsUsed([FromBody] UpdateDietRequestItem viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<DeactivatePremixRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[AxiosRedirectIfSuccess(Action = nameof(UpdateRequests), Controller = nameof(DietRequestController))]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> MarkPremixAsNotUsed([FromBody] UpdateDietRequestItem viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<ActivatePremixRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[AxiosRedirectIfSuccess(Action = nameof(UpdateRequests), Controller = nameof(DietRequestController))]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> MarkDietAsTemplated([FromBody] UpdateDietRequestItem viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<EnableDietRequestRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[AxiosRedirectIfSuccess(Action = nameof(UpdateRequests), Controller = nameof(DietRequestController))]
	[Authorize(Permissions.DietRequests.Update)]
	public async Task<IActionResult> MarkDietAsNotTemplated([FromBody] UpdateDietRequestItem viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<DisableDietRequestRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.Print)]
	public async Task<IActionResult> Print([FromBody] ReadDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		return await Print(_mapper.Map<PrintDietRequestViewModel>(viewModel));
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.DietRequests.Print)]
	public async Task<IActionResult> Print([FromQuery] int? id)
	{
		if (id is null)
		{
			throw new DietPreparationException(CommonErrorCode.ParametersNullException);
		}

		var request = new GetDietRequestQueryRequest { Id = id };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return await Print(_mapper.Map<PrintDietRequestViewModel>(response));
	}

	[Authorize(Permissions.DietRequests.Print)]
	public async Task<IActionResult> Print(PrintDietRequestViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var htmlContent = await _viewRenderer.RenderViewToString(ControllerContext, "Print", viewModel);
		return new OkObjectResult(new { printContent = htmlContent });
	}


	// TODO Try splitting this into ajax requests
	private async Task<MetadataSection> GetMetadata()
	{
		var drugListResponse = await _mediator.Send(new GetDrugsQueryRequest());
		var customerListResponse = await _mediator.Send(new GetCustomersQueryRequest());
		var locationListResponse = await _mediator.Send(new GetLocationsQueryRequest());
		var premixListResponse = await _mediator.Send(new GetPremixesQueryRequest());
		var basalDietListResponse = await _mediator.Send(new GetBasalDietsQueryRequest());

		var metadata = new MetadataSection();
		_mapper.Map(drugListResponse, metadata);
		_mapper.Map(customerListResponse, metadata);
		_mapper.Map(locationListResponse, metadata);
		_mapper.Map(premixListResponse, metadata);
		_mapper.Map(basalDietListResponse, metadata);

		return metadata;
	}
}