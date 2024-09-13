using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class UpdateFeedStuffRequestValidator : Validator<UpdateFeedStuffRequest>
{
	public UpdateFeedStuffRequestValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.WithErrorCodeRequired();

		RuleFor(s => s.Name)
			.NotNull()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeRequired();
	}
}