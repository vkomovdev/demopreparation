using DietPreparation.Application.Commands.Responses.FeedLabels;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.FeedLabels;

public record PrintFeedLabelRequest : PrintZplBaseRequest, IRequest<PrintFeedLabelResponse>
{
	public int Id { get; init; }
	public int Sequence { get; init; }
	public DateTime? DateRequest { get; init; }
	public DateTime? ExpirationDate { get; init; }
	public DateTime? ManufacturedDate { get; init; }
	public string? Comment { get; init; }
	public string? AdditionalComment { get; init; }
	public string? BagNumbers { get; init; }
	public bool NeedPrintBagNumbers { get; init; }
	public bool NeedPrintLabels { get; init; }
}