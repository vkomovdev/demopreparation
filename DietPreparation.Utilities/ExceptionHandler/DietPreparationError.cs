using DietPreparation.Common.Extensions;

namespace DietPreparation.Utilities.ExceptionHandler
{
	public class DietPreparationError
	{
		public DietPreparationError(Enum code, string message)
		{
			Code = code.GetNumberAsString();
			Message = message;
		}

		public DietPreparationError(string code, string message)
		{
			Code = code;
			Message = message;
		}

		public DietPreparationError(Enum code, string message, string details)
		{
			Code = code.GetNumberAsString();
			Message = message;
			Details = details;
		}

		public DietPreparationError(string code, string message, string details)
		{
			Code = code;
			Message = message;
			Details = details;
		}

		public string Message { get; }

		public string Code { get; }

		public string? Details { get; }
	}
}