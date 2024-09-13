using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Models.DTO.AuditLogs;

public record AuditFilterDto : IAuditFilterOptions
{
	public DateTime? DateStart { get; init; }
	public DateTime? DateEnd { get; init; }
	public string? LotYear { get; init; }
	public int? LotId { get; init; }
}
