using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditPremixDto
{
	public int AuditLogNumber { get; set; }
	public string? PremixName { get; init; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUoM { get; init; }
	public bool? PremixInWeight { get; init; }
}
