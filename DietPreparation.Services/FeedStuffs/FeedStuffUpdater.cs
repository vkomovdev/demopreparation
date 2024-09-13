using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.FeedStuffs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.FeedStuffs;

internal class FeedStuffUpdater : IFeedStuffUpdater
{
	private readonly IFeedStuffRepository _feedStuffRepository;
	private readonly IMapper _mapper;

	public FeedStuffUpdater(IFeedStuffRepository feedStuffRepository, IMapper mapper)
	{
		_feedStuffRepository = feedStuffRepository;
		_mapper = mapper;
	}

	public async Task<FeedStuffDto> UpdateAsync(FeedStuffDto feedStuff)
	{
		var createUpdateFeedStuffDao = _mapper.Map<CreateUpdateFeedStuffDao>(feedStuff);

		await _feedStuffRepository.UpsertAsync(createUpdateFeedStuffDao);

		return feedStuff;
	}
}