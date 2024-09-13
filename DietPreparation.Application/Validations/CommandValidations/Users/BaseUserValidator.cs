using DietPreparation.Application.Commands.Requests.Users;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations.Users;

public class BaseUserValidator : Validator<BaseUserRequest>
{
	public BaseUserValidator()
	{
		RuleFor(s => s.UserId!)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaxTextFieldLength(FieldLengthes.Small)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.FirstName!)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaxTextFieldLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.MiddleName!)
			.MaxTextFieldLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.LastName!)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaxTextFieldLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.Email!)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaxTextFieldLength(FieldLengthes.Middle)
			.WithErrorCodeInvalidLength()
			.EmailAddress()
			.WithErrorCodeInvalidEmail()
			.EmailAddressWithDomain(DefaultStrings.Domain)
			.WithErrorCodeInvalidEmailWithCustomDomain();
	}
}