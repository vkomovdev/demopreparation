using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Services.ExternalFeeds;

internal class ExternalFeedReader : IExternalFeedReader
{
	private readonly IDietRequestExternalFeedRepository _dietRequestExternalFeedRepository;

	public ExternalFeedReader(
		IDietRequestExternalFeedRepository dietRequestExternalFeedRepository)
	{
		_dietRequestExternalFeedRepository = dietRequestExternalFeedRepository;
	}

	public async ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId)
		=> await _dietRequestExternalFeedRepository.ReadRecordIdByRequestIdAsync(requestId);
}
