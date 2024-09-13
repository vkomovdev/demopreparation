namespace DietPreparation.Application.Common.Responses;

public interface IExceptionResponse
{
	public ExceptionResponse? Exception { get; init; }
}