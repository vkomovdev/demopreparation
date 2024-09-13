using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestExternalFeedRepository : IDietRequestExternalFeedRepository
{
	private const string RequestInsertExternalFeed = "DPS_REQUEST_INSERT_EXTERNAL_FEED";
	private const string RequestDeleteExternalFeed = "DPS_REQUEST_DELETE_EXTERNAL_FEED";

	private readonly IUnitOfWork _unitOfWork;

	public DietRequestExternalFeedRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> InsertAsync(DietRequestExternalFeedDao entity)
	{
		var cmd = $"{RequestInsertExternalFeed}" +
			$" {entity.REQUEST_ID}" +
			$", {entity.SUPPLIER_NAME.ToSqlValue()}" +
			$", {entity.LOT_NUMBER.ToSqlValue()}";

		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async ValueTask<int> ReadRecordIdByRequestIdAsync(int requestId)
	{
		var cmd = $"SELECT RECORD_ID FROM DP_REQUEST_EXTERNAL_FEED WHERE REQUEST_ID = {requestId}";
		return await _unitOfWork.QueryFirstAsync<int>(cmd);
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeleteExternalFeed} {requestId}");
}
