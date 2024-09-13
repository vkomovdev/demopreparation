using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.DietRequests.Interfaces;
public interface IDietRequestCreator : ICreate<DietRequestDto>
{
	Task<DietRequestDto> CreateAsync(DietRequestDto dietRequestDto, AuditCreateDto auditDto);
}
