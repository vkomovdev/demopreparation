using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.Customers;

public record CreateCustomerResponse : BaseResponse, IExceptionResponse
{
	public string CustomerId { get; init; } = string.Empty;
}