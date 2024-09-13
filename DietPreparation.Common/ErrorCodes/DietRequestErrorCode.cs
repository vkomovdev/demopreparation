using DietPreparation.Common.Attributes;

namespace DietPreparation.Common.ErrorCodes;

[ErrorCodes]
public enum DietRequestErrorCode
{
	ReadException = 3001,

	CreateException = 3002,

	UpdateException = 3003,

	RequesterNotFound = 3004,

	ReceiverNotFound = 3005,

	LocationNotFound = 3006,

	BasalDietNotFound = 3007,

	DrugNotFound = 3008,

	PremixNotFound = 3009,

	DietRequestNotFound = 3010,

	CloneException = 3011,

	DeleteException = 3012,

	UpdateDeletedDietRequest = 3013,

	UpdateLockedDietRequest = 3014,

	ActivateException = 3015,
}