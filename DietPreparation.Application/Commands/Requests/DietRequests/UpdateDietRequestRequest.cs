using DietPreparation.Application.Commands.Responses.DietRequests;
using MediatR;

namespace DietPreparation.Application.Commands.Requests.DietRequests;

public record UpdateDietRequestRequest : CreateDietRequestRequest, IRequest<UpdateDietRequestResponse>
{
	public int? Id { get; set; }

	public bool IsDeleted { get; set; }

	public bool IsLocked { get; set; }
}
