using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.BasalDiets;
public record GetBasalDietQueryResponse : BaseResponse, IExceptionResponse
{
	public BasalDietDto? BasalDiet { get; init; }
	public IEnumerable<IngredientDto>? Ingredients { get; set; }
}
