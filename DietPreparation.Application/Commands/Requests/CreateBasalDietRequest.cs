using DietPreparation.Application.Commands.Responses;
using DietPreparation.Models.DTO.BasalDiets;
using MediatR;

namespace DietPreparation.Application.Commands.Requests;

public record CreateBasalDietRequest : IRequest<CreateBasalDietResponse>
{
	public string Code { get; init; } = string.Empty;
	public string Name { get; init; } = string.Empty;
	public DateTime DateCreate { get; init; }
	public string CreatedBy { get; init; } = string.Empty;
	public bool IsLocked { get; init; }

	public IEnumerable<BasalDietIngredientDto>? BasalDietIngredients { get; init; }
}