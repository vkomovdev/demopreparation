using DietPreparation.Common.Extensions;
using DietPreparation.Utilities.Validator;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DietPreparation.Utilities.Validator;

public static class FluentValidationExtensions
{
	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeRequired<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.FieldRequired);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeInvalidValue<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.InvalidValue);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeFormatNotMatches<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.InvalidFormat);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeInvalidLength<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.InvalidLength);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeInvalidEmail<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.InvalidEmail);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeInvalidEmailWithCustomDomain<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.InvalidEmailWithCustomDomain);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeMustBeNonNegative<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.MustBeNonNegative);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeIncorrectOrderBy<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.IncorrectOrderBy);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeIncorrectSlope<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.IncorrectSlope);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeMustBeTotalAmountGreaterThanSamplesAmount<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.TotalAmountLessThanSamplesSum);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeMustBeTotalAmountGreaterThanSumOfIncludedWeights<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.TotalAmountLessThanWeightsSum);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeDrugMustBeActive<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.DrugMustBeActive);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodePremixMustBeActive<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.PremixMustBeActive);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeValueTooLong<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.ValueTooLong);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeValueTooSmall<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.ValueTooSmall);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeValueNotInPeriod<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.ValueNotInPeriod);
		return rule;
	}

	public static IRuleBuilderOptions<T, TProperty> WithErrorCodeValueNotInRange<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule)
	{
		rule.WithErrorCode(FluentValidationErrorCode.ValueNotInRange);
		return rule;
	}

	public static IRuleBuilderOptions<T, string> MaxTextFieldLength<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength = 250)
	{
		return ruleBuilder.MaximumLength(maxLength);
	}

	public static IRuleBuilderOptions<T, string> EmailAddressWithDomain<T>(this IRuleBuilder<T, string> ruleBuilder, string domain)
	{
		var domainRegex = new Regex($@"@{domain}$", RegexOptions.IgnoreCase);
		return ruleBuilder.EmailAddress().Matches(domainRegex);
	}

	private static IRuleBuilderOptions<T, TProperty> WithErrorCode<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, Enum errorCode)
	{
		rule.WithErrorCode(errorCode.GetNumberAsString());
		return rule;
	}
}