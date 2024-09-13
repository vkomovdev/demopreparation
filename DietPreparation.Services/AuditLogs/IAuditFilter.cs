using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.AuditLogs;

namespace DietPreparation.Services.AuditLogs;
public interface IAuditFilter : IFilterSorted<AuditItemDto, AuditFilterDto, IOrderBy, IPagination>
{
}
