using DietPreparation.Common.Enums;

namespace DietPreparation.Web.Models.AuditLogs;

public record AuditPremixViewModel
{
	public int? AuditLogNumber { get; init; }
	public string? PremixName { get; init; }
	public decimal? Amount { get; init; }
	public UnitOfMeasure? AmountUoM { get; init; }
	public bool? PremixInWeight { get; init; }
}
