using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses;
public record CreateUpdateLocationResponse : BaseResponse, IExceptionResponse
{
	public string Id { get; set; } = string.Empty;
}
