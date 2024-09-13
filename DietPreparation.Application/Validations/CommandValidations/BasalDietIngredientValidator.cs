using DietPreparation.Models.DTO.BasalDiets;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class BasalDietIngredientValidator : Validator<BasalDietIngredientDto>
{
	public BasalDietIngredientValidator()
	{
		RuleFor(s => s.IngredientId)
			.NotNull()
			.WithErrorCodeRequired()
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.PercentOfDiet)
			.GreaterThan(0)
			.WithErrorCodeMustBeNonNegative();
	}
}