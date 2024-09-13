using DietPreparation.Application.Queries.Responses;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Models.DTO.FilterOptions;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetAuditLogsQueryRequest :
	IRequest<GetAuditLogsQueryResponse>,
	IFilterable<AuditFilterDto>,
	IOrderable<OrderByDto>,
	IPaginable<PaginationDto>
{
	public AuditFilterDto? FilterBy { get; set; }
	public OrderByDto? OrderBy { get; set; }
	public PaginationDto? Pagination { get; set; }
}
