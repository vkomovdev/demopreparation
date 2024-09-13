namespace DietPreparation.Utilities.ExceptionHandler
{
	public class UnauthorizedException : DietPreparationException
	{
		private const string DefaultUnauthorizedMessage = "Attempt of unauthorized access";

		public UnauthorizedException(string message)
			: base(new DietPreparationError(CommonErrorCode.Unauthorized, message))
		{
		}

		public UnauthorizedException()
		: base(new DietPreparationError(CommonErrorCode.Unauthorized, DefaultUnauthorizedMessage))
		{
		}
	}
}