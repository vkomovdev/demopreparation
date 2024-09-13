using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations.Users;

public class EditUserValidator : Validator<EditUserRequest>
{
	public EditUserValidator()
	{
		RuleFor(s => s.KeyId)
			.GreaterThan(0)
			.WithErrorCodeRequired();

		RuleFor(s => s)
			.NotNull()
			.WithErrorCodeRequired()
			.SetValidator(new BaseUserValidator());
	}
}