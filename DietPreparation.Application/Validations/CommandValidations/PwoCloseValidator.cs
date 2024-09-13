using DietPreparation.Application.Commands.Requests.PWOs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class PwoCloseValidator : Validator<PwoCloseRequest>
{
	public PwoCloseValidator()
	{
		RuleFor(s => s.PwoId)
				.NotEmpty()
				.WithErrorCodeRequired();

		RuleFor(s => s.Mixer)
				.NotNull()
				.WithErrorCodeMustBeNonNegative();

		RuleFor(s => s.TimeCompleted)
				.NotNull()
				.WithErrorCodeRequired();

		RuleFor(s => s.Location)
				.NotNull()
				.WithErrorCodeRequired();

		RuleFor(s => s.DateCompleted)
				.NotNull()
				.WithErrorCodeRequired();

		RuleFor(s => s.CompletedBy)
				.NotNull()
				.WithErrorCodeRequired();

		RuleFor(s => s.BagCount)
				.GreaterThanOrEqualTo(0);
	}
}
