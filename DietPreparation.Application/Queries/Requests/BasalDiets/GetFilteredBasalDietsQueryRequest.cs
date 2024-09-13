using DietPreparation.Application.Queries.Responses.BasalDiets;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.BasalDiets;

public record GetFilteredBasalDietsQueryRequest : IRequest<GetBasalDietsQueryResponse>, IOrderable<OrderByDto>, IPaginable<PaginationDto>
{
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}