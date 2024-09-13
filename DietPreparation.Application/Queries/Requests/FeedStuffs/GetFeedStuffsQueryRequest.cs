using DietPreparation.Application.Queries.Responses.FeedStuffs;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.FeedStuffs;

public record GetFeedStuffsQueryRequest : IRequest<GetFeedStuffsQueryResponse>
{
	public OrderByDto? OrderBy { get; init; }
}