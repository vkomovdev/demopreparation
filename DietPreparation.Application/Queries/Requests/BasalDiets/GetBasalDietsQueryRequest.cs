using DietPreparation.Application.Queries.Responses.BasalDiets;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.BasalDiets;

public record GetBasalDietsQueryRequest : IRequest<GetBasalDietsQueryResponse>
{
}