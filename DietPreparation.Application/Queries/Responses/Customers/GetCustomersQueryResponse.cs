using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Customers;

public record GetCustomersQueryResponse : BasePaginationTableResponse, IExceptionResponse
{
	public IEnumerable<CustomerDto>? Customers { get; init; }
}