using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Common.Enums;

namespace DietPreparation.Application.Commands.Requests.AuditLogs;

public record CreateDietRequestWithAuditRequest : CreateDietRequestRequest
{
	public AuditChangeType ChangeType => AuditChangeType.Create;
	public string? ChangeReason => "Add Request";
	public string? ChangeOperator { get; set; }
}
