using Azure;
using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.Drugs;
using DietPreparation.Web.Models.TableOptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;
public class DrugController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;
	private readonly IAuthContextAccessor _authContextAccessor;

	public DrugController(IMediator mediator, IMapper mapper, IAuthContextAccessor authContextAccessor)
	{
		_mediator = mediator;
		_mapper = mapper;
		_authContextAccessor = authContextAccessor;
	}

	[HttpGet]
	[Authorize(Permissions.Drugs.View)]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Drugs.View)]
	public async Task<IActionResult> LoadDrugList([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetFilteredDrugsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok(_mapper.Map<DrugListViewModel>(response));
	}

	[HttpGet]
	[Authorize(Permissions.Drugs.Create)]
	public IActionResult Create()
	{
		var model = new DrugUpdateViewModel();
		model.UserId = _authContextAccessor.UserName[1..].Split('\\')[^1].ToUpper();

		return View(model);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Drugs.Create)]
	public async Task<IActionResult> Create([FromBody] DrugUpdateViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateUpdateDrugRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.Drugs.Update)]
	public async Task<IActionResult> Edit(string id)
	{
		if (string.IsNullOrEmpty(id))
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				new DietPreparationException(CommonErrorCode.ArgumentNullException));
		}

		if (!int.TryParse(id, out int drugId))
		{
			return StatusCode(StatusCodes.Status500InternalServerError,
				new DietPreparationException(CommonErrorCode.ArgumentNullException));
		}

		var request = new GetDrugQueryRequest { DrugId = drugId };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
		}

		var model = _mapper.Map<DrugUpdateViewModel>(response);
		model.UserId = _authContextAccessor.UserName[1..].Split('\\')[^1].ToUpper();

		return View(model);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Drugs.Update)]
	public async Task<IActionResult> Edit([FromBody] DrugUpdateViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateUpdateDrugRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}
}
