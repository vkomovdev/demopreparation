namespace DietPreparation.Services.ExternalFeeds;

public interface IExternalFeedReader
{
	ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId);
}
