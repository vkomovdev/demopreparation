using DietPreparation.Application.Queries.Responses;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetBatchQueryRequest : IRequest<GetBatchQueryResponse>
{
	public int? RequestId { get; set; }
}
