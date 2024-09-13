using DietPreparation.Application.Commands.Requests.AuditLogs;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class CreateDietRequestWithAuditValidator : Validator<CreateDietRequestWithAuditRequest>
{
	public CreateDietRequestWithAuditValidator()
	{
		Include(new CreateDietRequestValidator());

		RuleFor(s => s.ChangeOperator)
			.NotEmpty()
			.WithErrorCodeRequired();
	}
}