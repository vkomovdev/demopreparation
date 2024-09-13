using DietPreparation.Common.Attributes;

namespace DietPreparation.Utilities.ExceptionHandler;

[ErrorCodes]
public enum CommonErrorCode
{
	UnhandledException = 1,

	RouteNotFound = 2,

	EntityNotFound = 3,

	ConcurrentModification = 4,

	Unauthorized = 5,

	Forbidden = 6,

	UnprocessableEntity = 7,

	ArgumentNullException = 8,

	NotImplementedException = 9,

	NotImplementedOrderByException = 10,

	DatabaseConnectionException = 11,

	ParametersNullException = 12,

	ViewModelNullException = 13
}