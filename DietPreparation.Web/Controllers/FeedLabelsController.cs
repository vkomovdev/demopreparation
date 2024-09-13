using DietPreparation.Application.Commands.Requests.FeedLabels;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Requests.FeedLabels;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.FeedLabels;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Options;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class FeedLabelsController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	private readonly PrintOptions _printOptions;

	public FeedLabelsController(IMediator mediator, IMapper mapper, ApplicationOptions applicationOptions)
	{
		_mediator = mediator;
		_mapper = mapper;
		_printOptions = applicationOptions.Print;
	}

	[HttpGet]
	[Authorize(Permissions.FeedLabels.View)]
	public IActionResult Index()
	{
		return RedirectToAction("Print");
	}

	[HttpGet]
	[Authorize(Permissions.FeedLabels.Print)]
	public IActionResult Print()
	{
		return View("Index", new FeedLabelsSearchViewModel { Type = FeedLabelsType.Open });
	}

	[HttpGet]
	[Authorize(Permissions.FeedLabels.Print)]
	public IActionResult Reprint()
	{
		return View("Index", new FeedLabelsSearchViewModel { Type = FeedLabelsType.Reprint });
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedLabels.View)]
	public async Task<IActionResult> Search([FromQuery] TableOptionsViewModel tableOptions)
	{
		if (tableOptions is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<GetFeedLabelsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<FeedLabelListViewModel>(response);
		return Ok(new { viewModel.FeedLabels, response.TotalItems, response.PageSize, response.Page });
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.FeedLabels.View)]
	public async Task<IActionResult> BatchList(int requestId, FeedLabelsType type)
	{
		var request = new GetBatchesQueryRequest { RequestId = requestId, Type = _mapper.Map<BatchType>(type) };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = new FeedLabelBatchListViewModel { RequestId = requestId, Type = type };
		_mapper.Map(response, viewModel);

		return View(viewModel);
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.FeedLabels.Print)]
	public async Task<IActionResult> PrintLabel(int requestId, int sequence, FeedLabelsType type)
	{
		var request = new GetFeedLabelQueryRequest { Id = requestId, Sequence = sequence };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = new FeedLabelViewModel()
		{
			Type = type,
			ExpirationDate = DateTime.Now.AddMonths(12),
			ManufacturedDate = DateTime.Now.AddMonths(6),
			ZplExtension = _printOptions.DefaultZplExtension,
			PrinterKey = _printOptions.DefaultPrinterKey,
			Printers = _printOptions.Printers
		};
		_mapper.Map(response, viewModel);

		return View(viewModel);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedLabels.Print)]
	public async Task<IActionResult> PrintLabel([FromBody] FeedLabelViewModel viewModel)
	{
		// TODO Cancel printing if conditions are selected that do not satisfy printing or saving to database (from ui side)
		// For example:
		// BagNumbers.Count() > 1 && NoNeedPrintLabels
		// NeedPrintBagNumbers && NoNeedPrintLabels

		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<PrintFeedLabelRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		if (viewModel.NeedOnlyDownload)
		{
			return new OkObjectResult(new
			{
				downloadContents = response.Zpls?.Select(zpl => new
				{
					downloadContent = zpl.Content,
					downloadName = zpl.FileName,
					downloadType = DefaultStrings.TextPlain
				})
			});
		}

		return Ok();
	}

	[HttpGet]
	[Authorize(Permissions.FeedLabels.Print)]
	public IActionResult PrintLabelAdditive()
	{
		return View(new FeedLabelAdditiveViewModel()
		{
			NumberOfCopies = 1,
			ExpirationDate = DateTime.Now.AddMonths(6),
			ZplExtension = _printOptions.DefaultZplExtension,
			PrinterKey = _printOptions.DefaultPrinterKey,
			Printers = _printOptions.Printers
		});
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedLabels.Print)]
	public async Task<IActionResult> PrintLabelAdditive([FromBody] FeedLabelAdditiveViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<PrintFeedLabelAdditiveRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		if (viewModel.NeedOnlyDownload)
		{
			return new OkObjectResult(new
			{
				downloadContents = response.Zpls?.Select(zpl => new
				{
					downloadContent = zpl.Content,
					downloadName = zpl.FileName,
					downloadType = DefaultStrings.TextPlain
				})
			});
		}

		return Ok();
	}
}