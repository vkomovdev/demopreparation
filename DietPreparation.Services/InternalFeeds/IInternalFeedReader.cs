namespace DietPreparation.Services.InternalFeeds;

public interface IInternalFeedReader
{
	ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId);
}
