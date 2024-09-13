using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Commands.Requests.AuditLogs;

public record UpdateDietRequestWithAuditRequest : UpdateDietRequestRequest
{
	public AuditChangeType ChangeType => AuditChangeType.Update;
	public string? ChangeReason { get; init; }
	public string? ChangeOperator { get; set; }
}
