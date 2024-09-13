using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO.FeedLabels;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.FeedLabels.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.FeedLabels;

internal class FeedLabelCreator : IFeedLabelCreator
{
	private readonly IFeedLabelRepository _feedLabelRepository;
	private readonly IMapper _mapper;

	public FeedLabelCreator(IFeedLabelRepository feedLabelRepository, IMapper mapper)
	{
		_feedLabelRepository = feedLabelRepository;
		_mapper = mapper;
	}

	public async Task<PrintFeedLabelDto> CreateAsync(PrintFeedLabelDto dto)
	{
		var dao = _mapper.Map<PrintFeedLabelDao>(dto);

		await _feedLabelRepository.UpdateAsync(dao);

		return dto;
	}
}