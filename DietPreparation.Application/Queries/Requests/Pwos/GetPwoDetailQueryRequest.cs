using DietPreparation.Application.Queries.Responses.PWOs;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.PWOs;

public record GetPwoDetailQueryRequest : IRequest<GetPwoDetailQueryResponse>
{
	public required int Sequence { get; set; }
	public required int RequestId { get; set; }
}
