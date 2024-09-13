using DietPreparation.Application.Common.Responses;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.BasalDiets;

public record GetBasalDietsQueryResponse : BaseResponse, IExceptionResponse, IPagination
{
	public IEnumerable<BasalDietDto>? BasalDiets { get; set; }

	public int TotalItems { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
}

