using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Application.Queries.Requests.BasalDiets;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.BasalDiets;
using DietPreparation.Web.Models.BasalDiets.List;
using DietPreparation.Web.Models.TableOptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class BasalDietsController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public BasalDietsController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	[Authorize(Permissions.BasalDiets.View)]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.BasalDiets.View)]
	public async Task<IActionResult> BasalDietList([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetFilteredBasalDietsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
		}

		return Ok(_mapper.Map<BasalDietListViewModel>(response));
	}

	[HttpGet]
	[Authorize(Permissions.BasalDiets.Create)]
	public async Task<IActionResult> Create()
	{
		var request = new GetIngredientsQueryRequest();
		var response = await _mediator.Send(request);

		return View(_mapper.Map<EditBasalDietViewModel>(response));
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.BasalDiets.Update)]
	public async Task<IActionResult> Edit(int id)
	{
		var request = new GetBasalDietQueryRequest { BasalDietId = id };
		var response = await _mediator.Send(request);

		var viewModel = _mapper.Map<EditBasalDietViewModel>(response);
		return View(viewModel);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.BasalDiets.Create)]
	public async Task<IActionResult> Create([FromBody] EditBasalDietViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateBasalDietRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.BasalDiets.Update)]
	public async Task<IActionResult> Edit([FromBody] EditBasalDietViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<UpdateBasalDietRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}
}