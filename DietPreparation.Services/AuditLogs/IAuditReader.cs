using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Services.AuditLogs;
public interface IAuditReader : IReadRecord<int, AuditDto>
{
}
