using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations.Users;

public class CreateUserValidator : Validator<CreateUserRequest>
{
	public CreateUserValidator()
	{
		RuleFor(s => s)
			.NotNull()
			.WithErrorCodeRequired()
			.SetValidator(new BaseUserValidator());
	}
}