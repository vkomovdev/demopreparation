using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IPwoRepository
{
	Task ClosePWOAsync(PwoCloseDto sData);
	ValueTask<IEnumerable<PwoHeaderDao>> PWOsAsync(string sColumn, string sSlope);
	Task ConfirmPWO(string iPWO_ID, string iType);
	ValueTask<PwoHeaderDao> ReadPwoHeaderAsync(int requestId, int pwoId);
	ValueTask<IEnumerable<PwoIngredientDao>> ReadPwoIngredientsAsync(int pwoId);
	ValueTask<IEnumerable<PwoPremixDao>> ReadPwoPremixesAsync(int pwoId);
	ValueTask<IEnumerable<PwoDrugDao>> ReadPwoDrugsAsync(int pwoId);
	ValueTask<IEnumerable<PwoPremixDrugDao>> ReadPwoPremixDrugsAsync(int pwoId);
	Task InsertBatchAsync(CreateBatchDto model);
	ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllAsync(int requestId);
	ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllForLabelOpenAsync(int requestId);
	ValueTask<IEnumerable<PwoSelectAllDao>> ReadPwoSelectAllForLabelReprintAsync(int requestId);
}