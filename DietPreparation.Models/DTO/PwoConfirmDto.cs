using DietPreparation.Common.Enums;

namespace DietPreparation.Models.DTO;

public record PwoConfirmDto
{
	public required int PwoId { get; init; }
	public required PwoConfirmType Type { get; init; }
}