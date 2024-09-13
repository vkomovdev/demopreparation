using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Premixes.Interfaces;

public interface IPremixReader : IReadAll<MedicatedPremixDto>, IRead<int, MedicatedPremixDto>
{
	Task<IEnumerable<DietRequestPremixDto>> ReadByRequestIdAsync(int requestId);

	Task<IEnumerable<PwoPremixDto>> ReadPwoAsync();

	ValueTask<bool> IsAllProcessedAsync(int requestId);
}
