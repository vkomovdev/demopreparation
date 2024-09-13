using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Samples;

internal class SampleDeleter : ISampleDeleter
{
	private readonly IDietRequestSampleRepository _dietRequestSampleRepository;
	private readonly IMapper _mapper;

	public SampleDeleter(
		IDietRequestSampleRepository dietRequestSampleRepository,
		IMapper mapper)
	{
		_dietRequestSampleRepository = dietRequestSampleRepository;
		_mapper = mapper;
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
	{
		return await _dietRequestSampleRepository.DeleteByRequestIdAsync(requestId);
	}
}
