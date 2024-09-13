using DietPreparation.Common.Attributes;

namespace DietPreparation.Common.ErrorCodes;

[ErrorCodes]
public enum CustomerErrorCode
{
	ReadException = 9001,

	CreateException = 9002,

	UpdateException = 9003,

	CustomerNotFound = 9004,

	CustomerIdAlreadyExists = 9005,

	CustomerEmailAlreadyExists = 9006
}