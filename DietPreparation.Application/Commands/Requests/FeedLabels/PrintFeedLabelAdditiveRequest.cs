using DietPreparation.Application.Commands.Responses.FeedLabels;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.FeedLabels;

public record PrintFeedLabelAdditiveRequest : PrintZplBaseRequest, IRequest<PrintFeedLabelAdditiveResponse>
{
	public string? LotNumber { get; init; }
	public string? Id { get; init; }
	public string? Concentration { get; init; }
	public DateTime? ExpirationDate { get; init; }
	public string? Comment { get; init; }
	public string? AdditionalComment { get; init; }
	public int NumberOfCopies { get; init; }
}