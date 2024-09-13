using DietPreparation.Application.Queries.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.DietRequests;

public record GetDietRequestQueryRequest : IRequest<GetDietRequestQueryResponse>
{
	public int? Id { get; init; }
}