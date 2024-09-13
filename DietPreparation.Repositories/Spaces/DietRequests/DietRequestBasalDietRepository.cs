using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestBasalDietRepository : IDietRequestBasalDietRepository
{
	private const string RequestInsertBasalDiet = "DPS_REQUEST_INSERT_BASAL_DIET";
	private const string RequestDeleteBasalDiet = "DPS_REQUEST_DELETE_BASAL_DIET";

	private readonly IUnitOfWork _unitOfWork;

	public DietRequestBasalDietRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> InsertAsync(DietRequestBasalDietDao entity)
	{
		var cmd = $"{RequestInsertBasalDiet} {entity.REQUEST_ID}, {entity.BASAL_DIET_ID}";
		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async Task<DietRequestBasalDietDao> ReadByRequestIdAsync(int requestId)
	{
		var cmd = $"SELECT TOP 1 * FROM DP_REQUEST_BASAL_DIET WHERE REQUEST_ID = {requestId}";
		return await _unitOfWork.QuerySingleAsync<DietRequestBasalDietDao>(cmd);
	}

	public async ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId)
	{
		var cmd = $"SELECT RECORD_ID FROM DP_REQUEST_BASAL_DIET WHERE REQUEST_ID = {requestId}";
		return await _unitOfWork.QueryFirstAsync<int>(cmd);
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeleteBasalDiet} {requestId}");
}
