using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO.AuditLogs;

namespace DietPreparation.Application.Queries.Responses;

public record GetAuditLogsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<AuditItemDto>? AuditLogs { get; init; }

	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}