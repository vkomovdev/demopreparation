using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetNotClonedDietRequestsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<DietRequestTinyDto>? DietRequests { get; set; }
}
