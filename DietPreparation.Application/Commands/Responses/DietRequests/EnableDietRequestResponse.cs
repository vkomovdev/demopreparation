using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.DietRequests;

public record EnableDietRequestResponse : BaseResponse, IExceptionResponse
{
	public int Id { get; init; }
}
