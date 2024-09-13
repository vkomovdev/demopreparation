using DietPreparation.Application.Commands.Requests.FeedStuffs;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class CreateFeedStuffRequestValidator : Validator<CreateFeedStuffRequest>
{
	public CreateFeedStuffRequestValidator()
	{
		RuleFor(s => s.Name)
			.NotNull()
			.MaximumLength(FieldLengthes.Middle)
			.WithErrorCodeRequired();
	}
}