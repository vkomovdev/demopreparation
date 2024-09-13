using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetNotUsedMedicatedPremixesQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<DietRequestTinyDto>? MedicatedPremixes { get; set; }
}
