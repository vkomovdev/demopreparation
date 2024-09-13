using DietPreparation.Application.Queries.Responses;
using DietPreparation.Common.Enums;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetBatchesQueryRequest : IRequest<GetBatchesQueryResponse>
{
	public required int RequestId { get; set; }

	public required BatchType Type { get; set; }
}