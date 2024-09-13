using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.FeedStuffs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.FeedStuffs;

internal class FeedStuffReader : IFeedStuffReader
{
	private readonly IFeedStuffRepository _repository;
	private readonly IMapper _mapper;

	public FeedStuffReader(IFeedStuffRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public async Task<FeedStuffDto?> ReadAsync(string feedStuffId)
	{
		var feedStuff = await _repository.ReadAsync(feedStuffId);
		return feedStuff is not null ? _mapper.Map<FeedStuffDto>(feedStuff) : null;
	}

	public async Task<IEnumerable<FeedStuffDto>> ReadAllAsync()
	{
		var feedStuffs = await _repository.ReadAllAsync();
		return _mapper.Map<IEnumerable<FeedStuffDto>>(feedStuffs);
	}
}