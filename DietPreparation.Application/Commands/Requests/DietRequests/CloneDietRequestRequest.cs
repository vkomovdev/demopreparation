using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record CloneDietRequestRequest : IRequest<CloneDietRequestResponse>
{
	public int Id { get; set; }

	public int Print { get; set; }
}