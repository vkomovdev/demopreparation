using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.Drugs;

public record GetDrugQueryResponse : BaseResponse, IExceptionResponse
{
	public DrugDto? Drug { get; set; }
}