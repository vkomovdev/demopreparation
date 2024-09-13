namespace DietPreparation.Application.Common.Responses;

public abstract record BaseResponse : IExceptionResponse
{
	public ExceptionResponse? Exception { get; init; }
}