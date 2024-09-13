using DietPreparation.Common.Extensions;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces.DietRequests;

public class DietRequestSampleRepository : IDietRequestSampleRepository
{
	private const string RequestInsertSample = "DPS_REQUEST_INSERT_SAMPLE";
	private const string RequestSelectSample = "DPS_REQUEST_SELECT_SAMPLE";
	private const string RequestDeleteSample = "DPS_REQUEST_DELETE_SAMPLE";
	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public DietRequestSampleRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}

	public async Task<int> InsertAsync(DietRequestSampleDao entity)
	{
		var cmd = $"{RequestInsertSample}" +
			$" {entity.RECORD_ID}" +
			$", {entity.REQUEST_ID}" +
			$", {entity.AMOUNT}" +
			$", {entity.AMOUNT_UOM.ToSqlValue()}" +
			$", {entity.DISPOSITION.ToSqlValue()}" +
			$", {entity.ANALYSIS_TYPE.ToSqlValue()}" +
			$", {entity.COMMENT.ToSqlValue()}";

		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async Task<IEnumerable<DietRequestSampleDao>> ReadByRequestIdAsync(int requestId)
	{
		var cmd = $"{RequestSelectSample} {requestId}";
		return await _unitOfWork.QueryAsync<DietRequestSampleDao>(cmd);
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
		=> await _unitOfWork.ExecuteAsync($"{RequestDeleteSample} {requestId}");
}
