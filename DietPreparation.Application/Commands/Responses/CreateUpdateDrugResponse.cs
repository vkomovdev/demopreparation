using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses;

public record CreateUpdateDrugResponse : BaseResponse, IExceptionResponse
{
	public string Id { get; set; } = string.Empty;
}
