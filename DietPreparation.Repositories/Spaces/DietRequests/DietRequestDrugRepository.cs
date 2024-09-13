using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestDrugRepository : IDietRequestDrugRepository
{
	private const string RequestInsertDrug = "DPS_REQUEST_INSERT_DRUG";
	private const string RequestSelectDrug = "DPS_REQUEST_SELECT_DRUG";
	private const string RequestDeleteDrug = "DPS_REQUEST_DELETE_DRUG";

	private readonly IUnitOfWork _unitOfWork;

	public DietRequestDrugRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> InsertAsync(DietRequestDrugDao entity)
	{
		var cmd = $"{RequestInsertDrug}" +
			$" {entity.RECORD_ID}" +
			$", {entity.DRUG_ID}" +
			$", {entity.REQUEST_ID}" +
			$", {entity.AMOUNT}" +
			$", {entity.AMOUNT_UOM.ToSqlValue()}" +
			$", {entity.DRUG_IN_WEIGHT.ToSqlValue()}" +
			$", {entity.MFG_LOT.ToSqlValue()}";

		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async Task<IEnumerable<DietRequestDrugSelectDao>> ReadByRequestIdAsync(int requestId)
		=> await _unitOfWork.QueryAsync<DietRequestDrugSelectDao>($"{RequestSelectDrug} {requestId}");

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeleteDrug} {requestId}");
}
