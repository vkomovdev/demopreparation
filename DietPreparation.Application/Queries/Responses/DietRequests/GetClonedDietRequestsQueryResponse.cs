using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetClonedDietRequestsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<DietRequestTinyDto>? DietRequests { get; set; }
}