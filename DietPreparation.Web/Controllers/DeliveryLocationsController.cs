using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests.Locations;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.DeliveryLocations;
using DietPreparation.Web.Models.TableOptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class DeliveryLocationsController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public DeliveryLocationsController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	public IActionResult Index()
	{
		return View();
	}


	[HttpGet]
	[AxiosExceptionHandle]
	public async Task<IActionResult> LoadList([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetFilteredLocationsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}
		return Ok(_mapper.Map<DeliveryLocationListViewModel>(response));
	}

	[HttpGet]
	public IActionResult Create()
	{
		return View(new DeliveryLocationUpdateViewModel());
	}

	[HttpPost]
	[AxiosExceptionHandle]
	public async Task<IActionResult> Create([FromBody] DeliveryLocationUpdateViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateUpdateLocationRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	public async Task<IActionResult> Edit(int? id)
	{
		if (!id.HasValue)
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				new DietPreparationException(CommonErrorCode.ArgumentNullException));
		}

		var request = new GetLocationQueryRequest { LocationId = id.Value };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
		}

		return View(_mapper.Map<DeliveryLocationUpdateViewModel>(response));
	}

	[HttpPost]
	[AxiosExceptionHandle]
	public async Task<IActionResult> Edit([FromBody] DeliveryLocationUpdateViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateUpdateLocationRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}
}
