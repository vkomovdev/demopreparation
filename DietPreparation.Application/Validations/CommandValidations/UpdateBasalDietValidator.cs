using DietPreparation.Application.Commands.Requests;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class UpdateBasalDietValidator : Validator<UpdateBasalDietRequest>
{
	public UpdateBasalDietValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s.Code)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Name)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.BasalDietIngredients)
			.NotEmpty()
			.WithErrorCodeRequired();

		RuleFor(s => s)
			.Must(HasSumPercentOfIngredientsEqualsOneHundred)
			.WithErrorCodeMustBeTotalAmountGreaterThanSamplesAmount();
	}

	private bool HasSumPercentOfIngredientsEqualsOneHundred(UpdateBasalDietRequest dto)
	{
		var percentSum = dto.BasalDietIngredients?.Sum(x => x.PercentOfDiet) ?? 0;

		return Math.Round(percentSum, DefaultNumbers.DecimalDigitsCount) == 100;
	}
}