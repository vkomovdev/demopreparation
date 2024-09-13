using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses;

public record GetIngredientsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<IngredientDto>? Ingredients { get; set; }
}

