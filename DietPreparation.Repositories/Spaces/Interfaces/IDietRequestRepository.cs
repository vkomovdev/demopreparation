using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.DietRequests;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IDietRequestRepository :
	IUpsertRecord<DietRequestDao, DietRequestUpsertResultDao>,
	IReadRecord<int, DietRequestSelectDao>,
	IReadAllRecord<DietRequestSelectDao>,
	IDeleteRecord<int, bool>,
	ICloneRecord<int, bool>
{
	Task LockRequest(string iRequest_ID);
	Task UpdateRepeatUsed(string sRequest);
	Task UpdateRepeatActive(string sRequest);

	Task LockRequestAsync(int requestId);
	ValueTask<decimal> ReadAppSetupKeyAsync();
	ValueTask<bool> HasPremixAsync(int requestId);
	ValueTask<string> PreTestRequestAsync(int requestId);
	Task<MedicatedPremixDao> ReadMedicatedPremixAsync(int requestId);
	Task<IEnumerable<MedicatedPremixDao>> ReadMedicatedPremixesAsync();
	Task<bool> ActivateAsync(int requestId);

	Task<bool> EnableAsync(int requestId);
	Task<bool> DisableAsync(int requestId);
	Task<bool> ActivatePremixAsync(int requestId);
	Task<bool> DeactivatePremixAsync(int requestId);
}