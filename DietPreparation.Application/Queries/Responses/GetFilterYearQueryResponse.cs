using DietPreparation.Application.Common.Responses;

namespace DietPreparation.Application.Queries.Responses;
public record GetFilterYearQueryResponse : BaseResponse
{
	public int Year { get; set; }
}
