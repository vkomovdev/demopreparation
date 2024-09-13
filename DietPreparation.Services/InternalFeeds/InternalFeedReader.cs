using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Services.InternalFeeds;

internal class InternalFeedReader : IInternalFeedReader
{
	private readonly IDietRequestInternalFeedRepository _dietRequestInternalFeedRepository;

	public InternalFeedReader(
		IDietRequestInternalFeedRepository dietRequestInternalFeedRepository)
	{
		_dietRequestInternalFeedRepository = dietRequestInternalFeedRepository;
	}

	public async ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId)
		=> await _dietRequestInternalFeedRepository.ReadRecordIdByRequestIdAsync(requestId);
}
