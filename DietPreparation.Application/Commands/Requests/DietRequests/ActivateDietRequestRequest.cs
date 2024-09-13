using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record ActivateDietRequestRequest : IRequest<ActivateDietRequestResponse>
{
	public int? Id { get; init; }
}