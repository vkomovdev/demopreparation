namespace DietPreparation.Application.Commands.Requests.FeedLabels;

public abstract record PrintZplBaseRequest
{
	public bool NeedOnlyDownload { get; init; }
	public string? PrinterDirectory { get; init; }
	public string? ZplExtension { get; init; }
}