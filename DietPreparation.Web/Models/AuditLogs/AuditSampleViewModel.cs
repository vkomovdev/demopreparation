using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.AuditLogs;

public record AuditSampleViewModel
{
	public int? AuditLogNumber { get; init; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUnitOfMeasure { get; init; }
	public string? Disposition { get; init; }
	public AnalysisType? AnalysisType { get; init; }
	public string? Comment { get; init; }
}
