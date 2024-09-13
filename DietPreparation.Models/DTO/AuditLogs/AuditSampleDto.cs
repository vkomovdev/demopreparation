using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.AuditLogs;
public record AuditSampleDto
{
	public int AuditLogNumber { get; set; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUnitOfMeasure { get; init; }
	public string? Disposition { get; init; }
	public AnalysisType? AnalysisType { get; init; }
	public string? Comment { get; init; }
}
