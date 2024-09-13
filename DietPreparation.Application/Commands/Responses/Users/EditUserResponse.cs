using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses.Users;

public record EditUserResponse : BaseResponse, IExceptionResponse
{
	public string UserId { get; init; } = string.Empty;
}