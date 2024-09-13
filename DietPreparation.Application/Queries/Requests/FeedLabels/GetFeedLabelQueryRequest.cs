using DietPreparation.Application.Queries.Responses.FeedLabels;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.FeedLabels;

public record GetFeedLabelQueryRequest : IRequest<GetFeedLabelQueryResponse>
{
	public int? Id { get; init; }
	public int? Sequence { get; init; }
}