using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.DietRequests.Interfaces;

public interface IDietRequestDeleter : IDelete<int, bool>
{
	Task<bool> DeleteAsync(int value, AuditCreateDto audit);
}