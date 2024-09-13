using DietPreparation.Common.Attributes;

namespace DietPreparation.Common.ErrorCodes;

[ErrorCodes]
public enum UserErrorCode
{
	ReadException = 2001,

	CreateException = 2002,

	UpdateException = 2003,

	UserNotFound = 2004,

	UserIdAlreadyExists = 2005,
	CustomerIdAlreadyExists = 2006
}