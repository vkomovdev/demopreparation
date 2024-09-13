using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class ActivatePremixValidator : Validator<ActivatePremixRequest>
{
	public ActivatePremixValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0);
	}
}
