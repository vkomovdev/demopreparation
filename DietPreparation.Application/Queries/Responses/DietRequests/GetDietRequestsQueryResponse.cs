using DietPreparation.Application.Common.Responses;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO.DietRequests;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetDietRequestsQueryResponse : BaseResponse, IExceptionResponse, IPagination
{
	public IEnumerable<DietRequestSearchDto>? DietRequests { get; set; }
	public int Page { get; set; }
	public int PageSize { get; set; }
	public int TotalItems { get; set; }
}