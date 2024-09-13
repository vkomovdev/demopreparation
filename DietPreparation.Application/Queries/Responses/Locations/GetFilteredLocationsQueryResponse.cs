using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Locations;

public record GetFilteredLocationsQueryResponse : BasePaginationTableResponse, IExceptionResponse
{
	public IEnumerable<LocationDto>? Locations { get; init; }
}