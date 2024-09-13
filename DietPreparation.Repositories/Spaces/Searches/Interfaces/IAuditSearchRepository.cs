using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IAuditSearchRepository
{
	ValueTask<IEnumerable<AuditItemDao>> SearchAsync(IAuditFilterOptions filterDao, IOrderByDao orderByDao, IPagination paginationDao);
}