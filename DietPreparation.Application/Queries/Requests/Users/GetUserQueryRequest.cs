using DietPreparation.Application.Queries.Responses.Users;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Users;

public record GetUserQueryRequest : IRequest<GetUserQueryResponse>
{
	public string? UserId { get; init; }
}