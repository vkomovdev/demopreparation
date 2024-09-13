using Dapper;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.DietRequests;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestRepository : IDietRequestRepository
{
	private const string RequestUpsert = "DPS_REQUEST_IU";
	private const string RequestSelect = "DPS_REQUEST_SELECT";
	private const string RequestDelete = "DPS_REQUEST_DELETE_REQUEST";
	private const string RequestTable = "DP_REQUEST";

	private readonly IUnitOfWork _unitOfWork;

	public DietRequestRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<DietRequestUpsertResultDao> UpsertAsync(DietRequestDao entity)
	{
		var cmd = $"{RequestUpsert}" +
			$" {entity.REQUEST_ID}" +
			$", {entity.REQUESTOR_ID}" +
			$", {entity.DELIVER_TO_ID}" +
			$", {entity.LOCATION_ID}" +
			$", {entity.DELIVERY_NOTE.ToSqlValue()}" +
			$", {entity.STUDY_NUMBER.ToSqlValue()}" +
			$", {entity.PROJECT_NUMBER.ToSqlValue()}" +
			$", {entity.DATE_REQUEST.ToSqlValue()}" +
			$", {entity.DATE_NEEDED.ToSqlValue()}" +
			$", {entity.STUDY_TYPE.ToSqlValue()}" +
			$", {entity.REQUEST_TYPE.ToSqlValue()}" +
			$", {entity.DIET_NAME.ToSqlValue()}" +
			$", {entity.FEED_TYPE.ToSqlValue()}" +
			$", {entity.INTENDED_USE.ToSqlValue()}" +
			$", {entity.PREMIX.ToSqlValue()}" +
			$", {entity.DRUG.ToSqlValue()}" +
			$", {entity.SAMPLE.ToSqlValue()}" +
			$", {entity.REQUEST_AMOUNT}" +
			$", {entity.REQUEST_UOM.ToSqlValue()}" +
			$", {entity.FORM.ToSqlValue()}" +
			$", {entity.CONTROLLED_SUBSTANCE.ToSqlValue()}" +
			$", {entity.TOXIC_HAZARD.ToSqlValue()}" +
			$", {entity.HAZARD_CODE.ToSqlValue()}" +
			$", {entity.PACKING_INSTRUCTIONS.ToSqlValue()}" +
			$", {entity.MIXING_INSTRUCTIONS.ToSqlValue()}" +
			$", {entity.GENERAL_COMMENTS.ToSqlValue()}";

		var result = await _unitOfWork.QuerySingleAsync<(int requestId, int? lotYear, int? lotId)>(cmd);

		if (result is { requestId: > 0, lotYear: null, lotId: null })
		{
			var lotQuery = $"SELECT LOT_YEAR, LOT_ID from {RequestTable} WHERE REQUEST_ID = {result.requestId}";
			var lotInfo = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<(int? lotYear, int? lotId)>(lotQuery, transaction: _unitOfWork.Transaction);
			result = (result.requestId, lotInfo.lotYear, lotInfo.lotId);
		}

		return new DietRequestUpsertResultDao
		{
			REQUEST_ID = result.requestId,
			LOT_YEAR = result.lotYear,
			LOT_ID = result.lotId
		};
	}

	public async Task<DietRequestSelectDao> ReadAsync(int id)
		=> await _unitOfWork.QuerySingleAsync<DietRequestSelectDao>($"{RequestSelect} {id}");

	public async ValueTask<IEnumerable<DietRequestSelectDao>> ReadAllAsync()
		=> await _unitOfWork.QueryAsync<DietRequestSelectDao>(RequestSelect);

	public async ValueTask<bool> CloneAsync(int id)
	{
		var cmd = $"UPDATE {RequestTable} SET USEDASTEMPLATE = '{DefaultStrings.Yes}' WHERE REQUEST_ID = {id}";
		var result = await _unitOfWork.ExecuteAsync(cmd);

		return result > 0;
	}

	public async Task<bool> DeleteAsync(int requestId)
	{
		var result = await _unitOfWork.QuerySingleAsync<string>($"{RequestDelete} {requestId}");
		return result == DefaultStrings.Yes;
	}

	public async Task<bool> ActivateAsync(int requestId)
	{
		var result = await _unitOfWork.ExecuteAsync($"UPDATE {RequestTable} SET ISDELETED = 'N' WHERE REQUEST_ID = {requestId}");
		return result > 0;
	}

	public async Task LockRequest(string iRequest_ID)
	{
		var cmd = $"DPS_REQUEST_LOCK_REQUEST {iRequest_ID}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task UpdateRepeatUsed(string sRequest)
	{
		var cmd = $"DPS_REQUEST_UPDATE_REPEAT_USED {sRequest}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task UpdateRepeatActive(string sRequest)
	{
		var cmd = $"DPS_REQUEST_UPDATE_REPEAT_ACTIVE {sRequest}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task LockRequestAsync(int requestId)
	{
		await _unitOfWork.ExecuteAsync($"DPS_REQUEST_LOCK_REQUEST {requestId}");
	}

	public async ValueTask<decimal> ReadAppSetupKeyAsync()
	{
		var cmd = $"Select top 1 [Key] from DP_App_Setup";
		return await _unitOfWork.QueryFirstAsync<decimal>(cmd);
	}

	public async ValueTask<bool> HasPremixAsync(int requestId)
	{
		return await _unitOfWork.QueryFirstAsync<bool>($"SELECT PREMIX FROM {RequestTable} WHERE REQUEST_ID = {requestId}");
	}

	public async ValueTask<string> PreTestRequestAsync(int requestId)
	{
		return await _unitOfWork.QueryFirstAsync<string>($"DPS_TEST_REQUEST {requestId}");
	}

	public async Task<MedicatedPremixDao> ReadMedicatedPremixAsync(int requestId)
	{
		string cmd = @$"SELECT REQUEST_ID, LOT_YEAR, LOT_ID, DIET_NAME, ISDELETED, PremixUsed 
				FROM {RequestTable} 
				WHERE REQUEST_TYPE = 'Medicated Pre-Mix' 
				AND REQUEST_ID = {requestId}";

		return await _unitOfWork.QueryFirstAsync<MedicatedPremixDao>(cmd);
	}

	public async Task<IEnumerable<MedicatedPremixDao>> ReadMedicatedPremixesAsync()
	{
		string cmd =
			@$"SELECT REQUEST_ID, LOT_YEAR, LOT_ID, DIET_NAME, ISDELETED 
				FROM {RequestTable} 
				WHERE REQUEST_TYPE = 'Medicated Pre-Mix' 
				AND ISDELETED LIKE N'%{DefaultStrings.No}%' 
				AND PreMixUsed = '0' 
				ORDER BY LOT_YEAR DESC, LOT_ID DESC";

		return await _unitOfWork.QueryAsync<MedicatedPremixDao>(cmd);
	}

	public async Task<bool> DeactivatePremixAsync(int requestId)
	{
		var result = await _unitOfWork.QuerySingleAsync<string>
			($"DPS_REQUEST_UPDATE_PREMIX_USED {requestId}");
		return result == DefaultStrings.Yes;
	}

	public async Task<bool> ActivatePremixAsync(int requestId)
	{
		var result = await _unitOfWork.QuerySingleAsync<string>($"DPS_REQUEST_UPDATE_PREMIX_ACTIVE {requestId}");
		return result == DefaultStrings.Yes;
	}

	public async Task<bool> DisableAsync(int requestId)
	{
		var result = await _unitOfWork.QuerySingleAsync<string>($"DPS_REQUEST_UPDATE_REPEAT_USED {requestId}");
		return result == DefaultStrings.Yes;
	}

	public async Task<bool> EnableAsync(int requestId)
	{
		var result = await _unitOfWork.QuerySingleAsync<string>($"DPS_REQUEST_UPDATE_REPEAT_ACTIVE {requestId}");
		return result == DefaultStrings.Yes;
	}
}