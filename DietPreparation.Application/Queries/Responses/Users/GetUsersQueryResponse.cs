using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Users;

public record GetUsersQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<UserDto>? Users { get; init; }
}