using DietPreparation.Application.Commands.Responses;
using DietPreparation.Models.DTO;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record CreateUpdateLocationRequest : IRequest<CreateUpdateLocationResponse>
{
	public LocationUpdateDto? Location { get; set; }
}
