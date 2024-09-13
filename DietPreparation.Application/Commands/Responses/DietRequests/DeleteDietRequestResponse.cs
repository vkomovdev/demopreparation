using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.DietRequests;

public record DeleteDietRequestResponse : BaseResponse, IExceptionResponse
{
	public int Id { get; init; }
}