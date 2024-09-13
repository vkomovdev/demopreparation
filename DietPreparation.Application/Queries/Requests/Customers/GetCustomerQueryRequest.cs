using DietPreparation.Application.Queries.Responses.Customers;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Customers;

public record GetCustomerQueryRequest : IRequest<GetCustomerQueryResponse>
{
	public string? CustomerId { get; init; }
}