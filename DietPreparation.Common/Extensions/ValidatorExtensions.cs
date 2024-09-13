using FluentValidation;

namespace DietPreparation.Common.Extensions;

public static class ValidatorExtensions
{
	public static IRuleBuilderOptions<T, TProperty> In<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params TProperty[] validOptions)
	{
		if (validOptions?.Any() != true)
		{
			throw new ArgumentException("At least one valid option is expected", nameof(validOptions));
		}

		return ruleBuilder
			.Must(validOptions.Contains)
			.WithMessage($"{{PropertyName}} must be one of these values: {string.Join(", ", validOptions)}");
	}
}