using DietPreparation.Application.Queries.Responses.Locations;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Locations;
public record GetFilteredLocationsQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetFilteredLocationsQueryResponse>
{
	public PaginationDto? Pagination { get; set; }
	public OrderByDto? OrderBy { get; set; }
}
