using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Users;

public record GetUsersQueryRequest : IRequest<GetUsersQueryResponse>
{
	public OrderByDto? OrderBy { get; init; }
}