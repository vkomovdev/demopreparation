using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record DeactivatePremixRequest : IRequest<DeactivatePremixResponse>
{
	public int? Id { get; init; }
}
