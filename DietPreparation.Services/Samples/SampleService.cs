using DietPreparation.Models.DTO;
using DietPreparation.Services.Samples.Interfaces;

namespace DietPreparation.Services.Samples;

internal class SampleService : ISampleService
{
	private readonly ISampleCreator _sampleCreater;
	private readonly ISampleDeleter _sampleDeleter;
	private readonly ISampleReader _sampleReader;

	public SampleService(
		ISampleCreator sampleCreater,
		ISampleDeleter sampleDeleter,
		ISampleReader sampleReader)
	{
		_sampleCreater = sampleCreater;
		_sampleDeleter = sampleDeleter;
		_sampleReader = sampleReader;
	}

	public async Task<DietRequestSampleDto> CreateAsync(DietRequestSampleDto dietRequestSampleDto) => await _sampleCreater.CreateAsync(dietRequestSampleDto);

	public async Task<int> DeleteByRequestIdAsync(int requestId) => await _sampleDeleter.DeleteByRequestIdAsync(requestId);

	public async Task<IEnumerable<DietRequestSampleDto>> ReadByRequestIdAsync(int requestId) => await _sampleReader.ReadByRequestIdAsync(requestId);
}
