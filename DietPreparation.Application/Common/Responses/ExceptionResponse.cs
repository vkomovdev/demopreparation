using DietPreparation.Utilities.ExceptionHandler;
using Newtonsoft.Json;

namespace DietPreparation.Application.Common.Responses;

public record ExceptionResponse
{
	public string Message => JsonConvert.SerializeObject(Errors);

	public IList<DietPreparationError> Errors { get; init; } = new List<DietPreparationError>();
}