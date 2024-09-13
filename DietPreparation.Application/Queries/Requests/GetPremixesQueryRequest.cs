using DietPreparation.Application.Queries.Responses;
using MediatR;

namespace DietPreparation.Application.Queries.Requests;

public record GetPremixesQueryRequest : IRequest<GetPremixesQueryResponse>
{
}