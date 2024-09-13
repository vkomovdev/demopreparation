using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestPremixRepository : IDietRequestPremixRepository
{
	private const string RequestInsertPremix = "DPS_REQUEST_INSERT_PREMIX";
	private const string RequestSelectPremix = "DPS_REQUEST_SELECT_PREMIX";
	private const string RequestDeletePremix = "DPS_REQUEST_DELETE_PREMIX";
	private readonly IUnitOfWork _unitOfWork;

	public DietRequestPremixRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> InsertAsync(DietRequestPremixDao entity)
	{
		var cmd = $"{RequestInsertPremix}" +
			$" {entity.REQUEST_ID}" +
			$", {entity.PREMIX_ID}" +
			$", {entity.AMOUNT}" +
			$", {entity.AMOUNT_UOM.ToSqlValue()}" +
			$", {entity.PREMIX_IN_WEIGHT.ToSqlValue()}";

		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async Task<IEnumerable<DietRequestPremixSelectDao>> ReadByRequestIdAsync(int requestId)
	{
		var cmd = $"{RequestSelectPremix} {requestId}";
		return await _unitOfWork.QueryAsync<DietRequestPremixSelectDao>(cmd);
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeletePremix} {requestId}");
}
