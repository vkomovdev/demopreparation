using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record EnableDietRequestRequest : IRequest<EnableDietRequestResponse>
{
	public int? Id { get; init; }
}
