using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Drugs;

public record GetDrugsQueryResponse : BaseResponse, IExceptionResponse
{
	public IEnumerable<DrugDto>? Drugs { get; set; }
}
