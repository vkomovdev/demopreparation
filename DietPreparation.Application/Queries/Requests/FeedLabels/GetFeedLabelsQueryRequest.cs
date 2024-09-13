using DietPreparation.Application.Queries.Responses.FeedLabels;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.FeedLabels;

public record GetFeedLabelsQueryRequest : IFilterable<FeedLabelFilterDto>, IOrderable<OrderByDto>, IPaginable<PaginationDto>, IRequest<GetFeedLabelsQueryResponse>
{
	public FeedLabelFilterDto? FilterBy { get; set; }
	public PaginationDto? Pagination { get; set; }
	public OrderByDto? OrderBy { get; set; }
}