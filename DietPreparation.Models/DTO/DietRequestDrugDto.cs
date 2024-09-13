namespace DietPreparation.Models.DTO;

public record DietRequestDrugDto : DietRequestInnerEntityDto
{
	public int? DietRequestId { get; set; }

	public int? DrugId { get; init; }

	public DrugDto? Drug { get; init; }

	public string MfgLot { get; init; } = string.Empty;

	public override int? InnerEntityId => DrugId;
}