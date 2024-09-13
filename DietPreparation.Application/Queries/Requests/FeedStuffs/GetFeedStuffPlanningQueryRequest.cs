using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.FeedStuffs;

public record GetFeedStuffPlanningQueryRequest : IOrderable<OrderByDto>, IFilterable<FeedStuffPlanningFilterDto>, IPaginable<PaginationDto>, IRequest<GetFeedStuffPlanningQueryResponse>
{
	public OrderByDto? OrderBy { get; set; }
	public FeedStuffPlanningFilterDto? FilterBy { get; set; }

	public PaginationDto? Pagination { get; set; }
}