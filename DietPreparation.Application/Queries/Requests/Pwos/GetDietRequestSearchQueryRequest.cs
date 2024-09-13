using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.PWOs;

public record GetDietRequestSearchQueryRequest : IOrderable<OrderByDto>, IPaginable<PaginationDto>, IFilterable<PwoFilterDto>, IRequest<GetDietRequestSearchQueryResponse>
{
	public PwoFilterDto? FilterBy { get; set; }
	public PaginationDto? Pagination { get; set; }
	public OrderByDto? OrderBy { get; set; }
}