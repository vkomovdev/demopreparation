using DietPreparation.Application.Queries.Responses;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetIngredientsQueryRequest : IRequest<GetIngredientsQueryResponse>
{
	public int BasalDietId { get; init; }
}
