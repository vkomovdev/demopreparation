using DietPreparation.Utilities.ExceptionHandler;
using DietPreparation.Utilities.ExceptionHandler;
using FluentValidation;

namespace DietPreparation.Utilities.Validator;

public class ValidationExecutor<T> : IValidationExecutor<T>
{
	private readonly IEnumerable<IValidator> _validators;

	public ValidationExecutor(IEnumerable<IValidator<T>> validators)
	{
		_validators = validators;
	}

	public void Execute(T parameter)
	{
		var failures = _validators
			.Where(validator => validator.CanValidateInstancesOfType(parameter!.GetType()))
			.Select(validator => validator.Validate(new ValidationContext<T>(parameter)))
			.SelectMany(result => result.Errors)
			.Where(failure => failure != null)
			.ToList();

		if (failures.Any())
		{
			var dietErrors = failures
				.Select(src => new DietPreparationError(
					src.ErrorCode,
					ErrorCodesDescriptionStore.GetDescription(src.ErrorCode) ?? src.ErrorMessage,
					src.PropertyName))
				.ToList();

			throw new DietPreparationException(dietErrors);
		}
	}
}