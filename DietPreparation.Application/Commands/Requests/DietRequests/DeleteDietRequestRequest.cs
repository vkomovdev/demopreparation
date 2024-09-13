using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record DeleteDietRequestRequest : IRequest<DeleteDietRequestResponse>
{
	public int? Id { get; init; }
}