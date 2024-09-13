using DietPreparation.Application.Queries.Responses.BasalDiets;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.BasalDiets;
public record GetBasalDietQueryRequest : IRequest<GetBasalDietQueryResponse>
{
	public int BasalDietId { get; init; }
}
