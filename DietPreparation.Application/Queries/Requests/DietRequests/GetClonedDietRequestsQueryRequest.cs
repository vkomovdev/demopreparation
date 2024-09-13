using DietPreparation.Application.Queries.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Queries.Requests.DietRequests;

public record GetClonedDietRequestsQueryRequest : IRequest<GetClonedDietRequestsQueryResponse>
{
}
