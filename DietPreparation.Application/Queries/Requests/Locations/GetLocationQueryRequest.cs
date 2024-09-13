using DietPreparation.Application.Queries.Responses.Locations;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Locations;

public record GetLocationQueryRequest : IRequest<GetLocationQueryResponse>
{
	public int LocationId { get; init; }
}