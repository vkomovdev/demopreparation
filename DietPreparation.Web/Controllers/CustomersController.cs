using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Models.Common;
using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Web.Attributes;
using DietPreparation.Web.Models.Customers;
using DietPreparation.Web.Models.TableOptions;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace DietPreparation.Web.Controllers;

public class CustomersController : Controller
{
	private readonly IMediator _mediator;
	private readonly IMapper _mapper;

	public CustomersController(IMediator mediator, IMapper mapper)
	{
		_mediator = mediator;
		_mapper = mapper;
	}

	[HttpGet]
	[Authorize(Permissions.Customers.View)]
	public IActionResult Index()
	{
		return View();
	}

	[HttpGet]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Customers.View)]
	public async Task<IActionResult> Search([FromQuery] TableOptionsViewModel tableOptions)
	{
		if (tableOptions is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<GetCustomersQueryRequest>(tableOptions);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<CustomerListViewModel>(response);
		return Ok(viewModel);
	}

	[HttpGet]
	[Authorize(Permissions.Customers.Create)]
	public IActionResult Create()
	{
		return View(new CustomerViewModel());
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Customers.Create)]
	public async Task<IActionResult> Create([FromBody] CustomerViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<CreateCustomerRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}

	[HttpGet]
	[ExceptionHandle]
	[Authorize(Permissions.Customers.Update)]
	public async Task<IActionResult> Edit(string encodedId)
	{
		if (string.IsNullOrEmpty(encodedId))
		{
			throw new DietPreparationException(CommonErrorCode.ParametersNullException);
		}

		var request = new GetCustomerQueryRequest { CustomerId = HttpUtility.UrlDecode(encodedId) };
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		var viewModel = _mapper.Map<CustomerViewModel>(response);
		return View(viewModel);
	}

	[HttpPost]
	[AxiosExceptionHandle]
	[Authorize(Permissions.Customers.Update)]
	public async Task<IActionResult> Edit([FromBody] CustomerViewModel viewModel)
	{
		if (viewModel is null)
		{
			throw new DietPreparationException(CommonErrorCode.ViewModelNullException);
		}

		var request = _mapper.Map<EditCustomerRequest>(viewModel);
		var response = await _mediator.Send(request);

		if (response.Exception is not null)
		{
			throw new Exception(response.Exception.Message);
		}

		return Ok();
	}
}