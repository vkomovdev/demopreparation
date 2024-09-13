using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.DietRequests;

public record GetUsedMedicatedPremixesQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<DietRequestTinyDto>? MedicatedPremixes { get; set; }
}