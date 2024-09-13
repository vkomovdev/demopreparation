using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Commands.Responses;
public record EditFilterYearResponse: BaseResponse
{
	public int Year { get; set; }
}
