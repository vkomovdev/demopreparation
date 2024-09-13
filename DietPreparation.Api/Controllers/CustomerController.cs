using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Application.Queries.Responses.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietPreparation.ServicesApi.Controllers;

[ApiController]
[Route("api/cusomer")]
public class CustomerController : ControllerBase
{
	private readonly IMediator _mediatr;

	public CustomerController(IMediator mediatr)
	{
		_mediatr = mediatr;
	}

	[HttpGet]
	public async Task<ActionResult<GetCustomersQueryResponse>> GetCustomers(GetCustomersQueryRequest request)
	{
		return await _mediatr.Send(request);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult<GetCustomerQueryResponse>> GetCustomer(string id)
	{
		return await _mediatr.Send(new GetCustomerQueryRequest { CustomerId = id });
	}

	[HttpPost]
	public async Task<ActionResult<CreateCustomerResponse>> CreateCustomer(CreateCustomerRequest request)
	{
		return await _mediatr.Send(request);
	}

	[HttpPut]
	public async Task<ActionResult<EditCustomerResponse>> UpdateCustomer(EditCustomerRequest request)
	{
		return await _mediatr.Send(request);
	}
}
