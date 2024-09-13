using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Customers;

public record GetCustomerQueryResponse : BaseResponse, IExceptionResponse
{
	public CustomerDto? Customer { get; init; }
}