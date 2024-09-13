using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class UpdateDietRequestWithAuditValidator : Validator<UpdateDietRequestWithAuditRequest>
{
	public UpdateDietRequestWithAuditValidator()
	{
		Include(new UpdateDietRequestValidator());

		RuleFor(s => s.ChangeReason)
			.NotNull()
			.WithErrorCodeRequired()
			.MinimumLength(5)
			.WithErrorCodeInvalidLength();

		RuleFor(s => s.ChangeOperator)
			.NotEmpty()
			.WithErrorCodeRequired();
	}
}