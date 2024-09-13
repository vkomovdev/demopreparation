using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.DietRequests.Interfaces;
public interface IDietRequestUpdater : IUpdate<DietRequestDto>
{
	Task<bool> DeactivateAsync(int requestId);
	Task<bool> ActivateAsync(int requestId);
	Task<bool> DisableAsync(int requestId);
	Task<bool> EnableAsync(int requestId);
	Task<DietRequestDto> UpdateAsync(DietRequestDto dietRequestDto, AuditCreateDto auditCreate);
}
