using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DisableDietRequestValidator : Validator<DisableDietRequestRequest>
{
	public DisableDietRequestValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0);
	}
}
