using DietPreparation.Common.Attributes;

namespace DietPreparation.Common.ErrorCodes;

[ErrorCodes]
public enum FeedStuffErrorCode
{
	ReadException = 4001,

	CreateException = 4002,

	UpdateException = 4003,

	DuplicateNameNotAllowed = 4004
}