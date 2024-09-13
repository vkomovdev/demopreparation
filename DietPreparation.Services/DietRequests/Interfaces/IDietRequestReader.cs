using DietPreparation.Common.Enums;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.DietRequests.Interfaces;
public interface IDietRequestReader : IRead<int, DietRequestDto>, IReadAll<DietRequestSelectDto>
{
	Task<DietRequestDto> ReadFullAsync(int id);

	ValueTask<bool> IsPremixLockedAsync(int premixId);
	ValueTask<decimal> ReadMaxCapacityAsync(UnitOfMeasure dietRequest);
	ValueTask<string> PreTestRequestAsync(int requestId);
}
