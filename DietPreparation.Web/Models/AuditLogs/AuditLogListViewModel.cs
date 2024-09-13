namespace DietPreparation.Web.Models.AuditLogs;

public class AuditLogListViewModel : AuditLogFilterViewModel
{
	public IEnumerable<AuditLogViewModel>? AuditLogs { get; init; }

	public int TotalItems { get; init; }
	public int Page { get; init; }
	public int PageSize { get; init; }
}