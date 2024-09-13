using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditCreateDto
{
	public AuditChangeType? ChangeType { get; set; }
	public string? ChangeReason { get; init; }
	public string? ChangeOperator { get; init; }
}