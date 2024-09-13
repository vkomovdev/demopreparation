using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record DisableDietRequestRequest : IRequest<DisableDietRequestResponse>
{
	public int? Id { get; init; }
}