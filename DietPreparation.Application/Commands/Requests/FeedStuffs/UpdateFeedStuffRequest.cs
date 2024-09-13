using DietPreparation.Application.Commands.Responses.FeedStuffs;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.FeedStuffs;

public record UpdateFeedStuffRequest : IRequest<UpdateFeedStuffResponse>
{
	public required string Id { get; init; }
	public required string Name { get; init; }
}