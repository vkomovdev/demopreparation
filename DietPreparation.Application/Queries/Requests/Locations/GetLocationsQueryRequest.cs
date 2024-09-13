using DietPreparation.Application.Queries.Responses.Locations;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Locations;

public record GetLocationsQueryRequest : IRequest<GetLocationsQueryResponse>
{
	public int LocationId { get; init; }
}
