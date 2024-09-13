using DietPreparation.Application.Commands.Responses.FeedStuffs;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.FeedStuffs;

public record CreateFeedStuffRequest : IRequest<CreateFeedStuffResponse>
{
	public required string Name { get; init; }
}