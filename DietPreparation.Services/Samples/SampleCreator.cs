using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Samples;

internal class SampleCreator : ISampleCreator
{
	private readonly IDietRequestSampleRepository _dietRequestSampleRepository;
	private readonly IMapper _mapper;

	public SampleCreator(
		IDietRequestSampleRepository dietRequestSampleRepository,
		IMapper mapper)
	{
		_dietRequestSampleRepository = dietRequestSampleRepository;
		_mapper = mapper;
	}

	public async Task<DietRequestSampleDto> CreateAsync(DietRequestSampleDto dietRequestSampleDto)
	{
		dietRequestSampleDto.Id = await _dietRequestSampleRepository.InsertAsync(
			_mapper.Map<DietRequestSampleDao>(dietRequestSampleDto));

		return dietRequestSampleDto;
	}
}
