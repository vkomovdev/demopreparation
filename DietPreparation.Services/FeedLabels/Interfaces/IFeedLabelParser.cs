namespace DietPreparation.Services.FeedLabels.Interfaces;

public interface IFeedLabelParser
{
	IEnumerable<int> ParsePageNumbers(string? input);
}