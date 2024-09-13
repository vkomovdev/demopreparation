using DietPreparation.Models.DTO;

namespace DietPreparation.Services.Samples.Interfaces;

public interface ISampleReader
{
	Task<IEnumerable<DietRequestSampleDto>> ReadByRequestIdAsync(int requestId);
}
