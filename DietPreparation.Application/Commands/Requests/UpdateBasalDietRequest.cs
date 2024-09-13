using DietPreparation.Application.Commands.Responses;
using DietPreparation.Models.DTO.BasalDiets;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record UpdateBasalDietRequest : IRequest<UpdateBasalDietResponse>
{
	public int Id { get; set; }
	public string Code { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;

	public IEnumerable<BasalDietIngredientDto>? BasalDietIngredients { get; init; }
}
