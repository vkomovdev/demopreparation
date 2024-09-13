using DietPreparation.Application.Common.Responses;
using DietPreparation.Models.DTO;

namespace DietPreparation.Application.Queries.Responses.PWOs;

public record GetPwoDetailQueryResponse : BaseResponse
{
	public int RequestId { get; set; }
	public PwoHeaderDto? Header { get; set; }
	public IEnumerable<PwoIngredientDto>? Ingredients { get; set; }
	public IEnumerable<PwoDrugDto>? Drugs { get; set; }
	public IEnumerable<PwoPremixDto>? Premixes { get; set; }
	public IEnumerable<PwoPremixDrugDto>? PremixDrugs { get; set; }
}