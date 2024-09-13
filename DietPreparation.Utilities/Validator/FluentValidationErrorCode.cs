using DietPreparation.Common.Attributes;

namespace DietPreparation.Utilities.Validator;

[ErrorCodes]
public enum FluentValidationErrorCode
{
	FieldRequired = 1001,

	InvalidLength = 1002,

	InvalidEmail = 1003,

	InvalidEmailWithCustomDomain = 1004,

	MustBeNonNegative = 1005,

	IncorrectOrderBy = 1006,

	IncorrectSlope = 1007,

	InvalidValue = 1008,

	TotalAmountLessThanWeightsSum = 1009,

	TotalAmountLessThanSamplesSum = 1010,

	DrugMustBeActive = 1011,

	PremixMustBeActive = 1012,

	InvalidFormat = 1013,

	ValueTooLong = 1014,

	ValueTooSmall = 1015,

	ValueNotInPeriod = 1016,

	ValueNotInRange = 1017
}