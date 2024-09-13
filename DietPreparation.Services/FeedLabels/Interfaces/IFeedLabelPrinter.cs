namespace DietPreparation.Services.FeedLabels.Interfaces;

public interface IFeedLabelPrinter
{
	Task PrintAsync(string? content, string? fileName, string? printerDirectory);
}