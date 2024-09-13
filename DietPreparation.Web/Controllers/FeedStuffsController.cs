using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Application.Queries.Requests.FeedStuffs;
using DietPreparation.Common.Consts;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.FeedStuffs;
using DietPreparation.Web.Models.TableOptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DietPreparation.Web.Controllers;

public class FeedStuffsController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public FeedStuffsController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	[Authorize(Permissions.FeedStuffs.View)]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedStuffs.View)]
	public async Task<IActionResult> Search([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetFeedStuffsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<FeedStuffListViewModel>(response);
		return Ok(new { feedStuffs = viewModel.FeedStuffs });
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View(new FeedStuffViewModel());
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedStuffs.Create)]
	public async Task<IActionResult> Create([FromBody] FeedStuffViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateFeedStuffRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.FeedStuffs.Update)]
	public async Task<IActionResult> Edit(string encodedId)
	{
		if (string.IsNullOrEmpty(encodedId))
		{
			throw new DietPreparationException(CommonErrorCode.ParametersNullException);
		}

		var request = new GetFeedStuffQueryRequest { FeedStuffId = HttpUtility.UrlDecode(encodedId) };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<FeedStuffViewModel>(response);
		return View(viewModel);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedStuffs.Update)]
	public async Task<IActionResult> Edit([FromBody] FeedStuffViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<UpdateFeedStuffRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[Authorize(Permissions.FeedStuffPlanning.View)]
	public async Task<IActionResult> Planning()
	{
		var ingredients = await _mediator.Send(new GetFeedStuffsQueryRequest());

		var model = new FeedStuffPlanningViewModel
		{
			Ingredients = _mapper.Map<FeedStuffListViewModel>(ingredients),
			DateStart = DateTime.Now.AddMonths(-6).ToString(FormatStrings.NetDateFormat),
			DateEnd = DateTime.Now.Date.ToString(FormatStrings.NetDateFormat)
		};

		return View(model);
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.FeedStuffPlanning.View)]
	public async Task<IActionResult> PlanningList([FromQuery] TableOptionsViewModel tableOptions)
	{
		if (tableOptions is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<GetFeedStuffPlanningQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok(_mapper.Map<FeedStuffPlanningViewModel>(response));
	}
}