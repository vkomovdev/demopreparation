using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DeleteDietRequestWithAuditValidator : Validator<DeleteDietRequestWithAuditRequest>
{
	public DeleteDietRequestWithAuditValidator()
	{
		Include(new DeleteDietRequestValidator());

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