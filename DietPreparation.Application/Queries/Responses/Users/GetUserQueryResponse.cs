using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Users;

public record GetUserQueryResponse : BaseResponse, IExceptionResponse
{
	public UserDto? User { get; init; }
}