using DietPreparation.Common.Attributes;

namespace DietPreparation.Common.ErrorCodes;

[ErrorCodes]
public enum FeedLabelErrorCode
{
	ReadException = 5001,

	PrintException = 5002,

	PrintIOException = 5003,

	PrintAccessDenied = 5004,

	ParseBagNumbersException = 5005
}