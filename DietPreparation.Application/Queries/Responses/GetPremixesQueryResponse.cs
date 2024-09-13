using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses;

public record GetPremixesQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<MedicatedPremixDto>? Premixes { get; set; }
}
