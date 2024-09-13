using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record ActivatePremixRequest : IRequest<ActivatePremixResponse>
{
	public int? Id { get; init; }
}
