using DietPreparation.Application.Queries.Responses.FeedStuffs;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.FeedStuffs;

public record GetFeedStuffQueryRequest : IRequest<GetFeedStuffQueryResponse>
{
	public required string FeedStuffId { get; init; }
}