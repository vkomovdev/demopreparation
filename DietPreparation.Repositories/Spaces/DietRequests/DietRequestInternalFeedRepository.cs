using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestInternalFeedRepository : IDietRequestInternalFeedRepository
{
	private const string RequestInsertInternalFeed = "DPS_REQUEST_INSERT_INTERNAL_FEED";
	private const string RequestDeleteInternalFeed = "DPS_REQUEST_DELETE_INTERNAL_FEED";
	private readonly IUnitOfWork _unitOfWork;

	public DietRequestInternalFeedRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> InsertAsync(DietRequestInternalFeedDao entity)
	{
		var cmd = $"{RequestInsertInternalFeed}" +
			$" {entity.REQUEST_ID}" +
			$", {entity.LOT_NUMBER_ID}" +
			$", {entity.SEQUENCE_NUMBER}";

		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId)
	{
		var cmd = $"SELECT RECORD_ID FROM DP_REQUEST_INTERNAL_FEED WHERE REQUEST_ID = {requestId}";
		return await _unitOfWork.QueryFirstAsync<int>(cmd);
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeleteInternalFeed} {requestId}");
}
