using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class FilterYearController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public FilterYearController(IMediator mediator, IMapper mapper)
	{
		_mapper = mapper;
		_mediator = mediator;
	}

	[Authorize(Permissions.Administration.YearFiltering)]
	[AxiosExceptionHandle]
	public async Task<IActionResult> Index()
	{
		var response = await _mediator.Send(new GetFilterYearQueryRequest());

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return View(_mapper.Map<FilterYearViewModel>(response));
	}

	[Authorize(Permissions.Administration.YearFiltering)]
	[AxiosExceptionHandle]
	public async Task<IActionResult> Create([FromBody] FilterYearViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var response = await _mediator.Send(_mapper.Map<EditFilterYearRequest>(viewModel));

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}
}