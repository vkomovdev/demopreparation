using DietPreparation.Application.Queries.Responses.Drugs;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.Drugs;

public record GetDrugsQueryRequest : IRequest<GetDrugsQueryResponse>
{
}
