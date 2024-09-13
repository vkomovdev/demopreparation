using DietPreparation.Application.Queries.Requests;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.AuditLogs;
using DietPreparation.Web.Models.TableOptions;
using DietPreparation.Web.Utilities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.Web.Controllers;

public class AuditLogsController : Controller
{
	private readonly ViewRenderer _viewRenderer;
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public AuditLogsController(ViewRenderer viewRenderer, IMediator mediator, IMapper mapper)
	{
		_viewRenderer = viewRenderer;
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
	public async Task<IActionResult> AuditLogList([FromQuery] TableOptionsViewModel tableOptions)
	{
		var request = _mapper.Map<GetAuditLogsQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			return StatusCode(StatusCodes.Status500InternalServerError, response.Exception);
		}

		return Ok(_mapper.Map<AuditLogListViewModel>(response));
	}

	[HttpGet]
	[ExceptionHandle]
	public async Task<IActionResult> Details(int? id)
	{
		if (!id.HasValue)
		{
			throw new DietPreparationException(CommonErrorCode.ArgumentNullException);
		}

		var request = new GetAuditLogQueryRequest { Id = id.Value };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var model = _mapper.Map<AuditLogDetailsViewModel>(response);
		return View(model);
	}
}