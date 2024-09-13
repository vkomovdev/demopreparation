using DietPreparation.Application.Commands.Responses;
using DietPreparation.Models.DTO;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record CreateUpdateDrugRequest : IRequest<CreateUpdateDrugResponse>
{
	public DrugUpdateDto? Drug { get; set; }
}