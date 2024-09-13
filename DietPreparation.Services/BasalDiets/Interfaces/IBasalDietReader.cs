using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.BasalDiets.Interfaces;

public interface IBasalDietReader : IReadAll<BasalDietDto>, IRead<int, BasalDietDto>
{
	Task<DietRequestBasalDietDto> ReadByRequestIdAsync(int requestId);
	Task<int> ReadRecordIdByRequestIdAsync(int requestId);
}
