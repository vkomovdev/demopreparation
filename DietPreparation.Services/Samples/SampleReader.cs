using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Samples;

internal class SampleReader : ISampleReader
{
	private readonly IDietRequestSampleRepository _dietRequestSampleRepository;
	private readonly IMapper _mapper;

	public SampleReader(
		IDietRequestSampleRepository dietRequestSampleRepository,
		IMapper mapper)
	{
		_dietRequestSampleRepository = dietRequestSampleRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<DietRequestSampleDto>> ReadByRequestIdAsync(int requestId)
	{
		var result = await _dietRequestSampleRepository.ReadByRequestIdAsync(requestId);

		return _mapper.Map<IEnumerable<DietRequestSampleDto>>(result);
	}
}
