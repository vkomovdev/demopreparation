using DietPreparation.Application.Queries.Responses;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetAuditLogQueryRequest : IRequest<GetAuditLogQueryResponse>
{
	public int Id { get; init; }
}