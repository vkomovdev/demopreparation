using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Commands.Requests.AuditLogs;

public record DeleteDietRequestWithAuditRequest : DeleteDietRequestRequest
{
	public AuditChangeType ChangeType => AuditChangeType.Delete;
	public string? ChangeReason { get; init; }
	public string? ChangeOperator { get; set; }
}