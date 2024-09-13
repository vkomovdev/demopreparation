using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO.AuditLogs;

namespace DietPreparation.Application.Queries.Responses;

public record GetAuditLogQueryResponse : BaseResponse, IExceptionResponse
{
	public AuditDto AuditLog { get; init; }
}