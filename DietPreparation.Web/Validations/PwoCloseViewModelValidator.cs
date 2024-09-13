using DietPreparation.Utilities.Validator;
using DietPreparation.Web.Models.PWOs;
using FluentValidation;

namespace DietPreparation.Web.Validations;

public class PwoCloseViewModelValidator : Validator<PwoCloseViewModel>
{
	public PwoCloseViewModelValidator()
	{
		RuleFor(s => s.PwoId)
				.NotEmpty();
		RuleFor(s => s.Mixer)
				.NotNull()
				.WithErrorCodeMustBeNonNegative();
		RuleFor(s => s.TimeCompleted)
				.NotNull();
		RuleFor(s => s.Location)
				.NotNull();
		RuleFor(s => s.DateCompleted)
				.NotNull();
		RuleFor(s => s.CompletedBy)
				.NotNull();
		RuleFor(s => s.BagCount)
				.GreaterThanOrEqualTo(0);
	}
}
