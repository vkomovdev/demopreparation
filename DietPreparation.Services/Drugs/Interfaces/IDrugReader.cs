using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Drugs.Interfaces;

public interface IDrugReader : IReadAll<DrugDto>, IRead<int, DrugDto>
{
	Task<IEnumerable<DietRequestDrugDto>> ReadByRequestIdAsync(int requestId);
}
