using DietPreparation.Application.Queries.Requests.Users;
using DietPreparation.Common.Consts;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.QueryValidations;

public class GetUserQueryValidator : Validator<GetUserQueryRequest>
{
	public GetUserQueryValidator()
	{
		RuleFor(s => s.UserId!)
			.NotEmpty()
			.WithErrorCodeRequired()
			.MaxTextFieldLength(FieldLengthes.Small)
			.WithErrorCodeInvalidLength();
	}
}
