using DietPreparation.Models.DTO;

namespace DietPreparation.Services.PWOs.Interfaces;

public interface IPwoReader
{
	ValueTask<PwoHeaderDto> ReadHeaderAsync(int requestId, int pwoId);
	ValueTask<IEnumerable<PwoDrugDto>> ReadDrugsAsync(int pwoId);
	ValueTask<IEnumerable<PwoPremixDrugDto>> ReadPremixDrugsAsync(int pwoId);
	ValueTask<IEnumerable<PwoIngredientDto>> ReadIngredientsAsync(int pwoId);
	ValueTask<IEnumerable<PwoPremixDto>> ReadPremixesAsync(int pwoId);
	ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllAsync(int requestId);
	ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllForLabelOpenAsync(int requestId);
	ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllForLabelReprintAsync(int requestId);
}