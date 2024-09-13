using DietPreparation.Common.Extensions;
using Newtonsoft.Json;

namespace DietPreparation.Utilities.ExceptionHandler
{
	public class DietPreparationException : Exception
	{
		public DietPreparationException(IEnumerable<DietPreparationError> errors)
		{
			Errors.AddRange(errors);
		}

		public DietPreparationException(DietPreparationError error)
		{
			Errors.Add(error);
		}

		public DietPreparationException(Enum code)
		{
			var message = ErrorCodesDescriptionStore.GetDescription(code)!;
			Errors.Add(new DietPreparationError(code, message));
		}

		public DietPreparationException(Enum code, string details)
		{
			var message = ErrorCodesDescriptionStore.GetDescription(code)!;
			Errors.Add(new DietPreparationError(code, message, details));
		}

		public DietPreparationException(Enum code, Exception innerException)
			: base(string.Empty, innerException)
		{
			var message = ErrorCodesDescriptionStore.GetDescription(code)!;
			Errors.Add(new DietPreparationError(code, message));
		}

		public override string Message => JsonConvert.SerializeObject(Errors);

		public IList<DietPreparationError> Errors { get; } = new List<DietPreparationError>();
	}
}