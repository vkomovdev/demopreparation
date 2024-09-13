namespace DietPreparation.Models.DTO;

public record DietRequestPremixDto : DietRequestInnerEntityDto
{
	public int? DietRequestId { get; set; }

	public int? PremixId { get; init; }

	public MedicatedPremixDto? Premix { get; init; }

	public override int? InnerEntityId => PremixId;
}