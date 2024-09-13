using DietPreparation.Application.Commands.Requests.DietRequests;
using DietPreparation.Utilities.Validator;
using FluentValidation;

namespace DietPreparation.Application.Validations.CommandValidations;

public class DeactivatePremixValidator : Validator<DeactivatePremixRequest>
{
	public DeactivatePremixValidator()
	{
		RuleFor(s => s.Id)
			.NotNull()
			.GreaterThan(0);
	}
}