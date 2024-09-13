using DietPreparation.Models.DAO;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface ITestRepository
{
	Task PWO_Rollback1();
	Task PWO_Rollback2(string iLotNum);
	Task CheckRequest(string sRequest_ID);
	ValueTask<bool> CheckExists(string table, string searchParam, string? searchId);
	ValueTask<IEnumerable<DietRequestDao>> getRequest(string requestID);
}