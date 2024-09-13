using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;
public interface IAuditRepository : IReadRecord<int, AuditDao>
{
	Task<IEnumerable<AuditDrugDao>> ReadDrugsAsync(int auditLogNumber);
	Task<IEnumerable<AuditPremixDao>> ReadPremixesAsync(int auditLogNumber);
	Task<IEnumerable<AuditSampleDao>> ReadSamplesAsync(int auditLogNumber);

	Task<int> CreateDietRequestAuditAsync(AuditDao auditDao);
	Task<int> CreateDrugAsync(AuditDrugDao auditDrugDao);
	Task<int> CreatePremixAsync(AuditPremixDao auditPremixDao);
	Task<int> CreateSampleAsync(AuditSampleDao auditSampleDao);
}
