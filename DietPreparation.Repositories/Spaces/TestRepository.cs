using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;
internal class TestRepository : ITestRepository
{
	private const string DpsTestExistsProcedure = "DPS_TEST_EXISTS";
	private const string ExistenceFlag = "Exists";

	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public TestRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}
	public async Task PWO_Rollback1()
	{
		var cmd = "DPS_TEST_CLEAR_PWOs";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task PWO_Rollback2(string iLotNum)
	{
		var cmd = $"DPS_TEST_ROLLBACK_LOT 2004, {iLotNum}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task CheckRequest(string sRequest_ID)
	{
		// this procedure performs a final check on the request before a process
		//   work order is generated.  Returns OK or an error string. MPH

		var cmd = $"DPS_TEST_REQUEST {sRequest_ID}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	/// <summary>
	/// This procedure checks for an existing drug, basal, or ingredient record
	/// before inserting a new item with the same name.
	/// sLibrary must be BASAL, DRUG OR INGREDIENT
	/// </summary>
	public async ValueTask<bool> CheckExists(string table, string searchParam, string searchId)
	{
		var cmd = $"{DpsTestExistsProcedure} '{table}', '{searchParam}',{searchId}";
		var result = (await _unitOfWork.QueryAsync<string>(cmd)).FirstOrDefault();

		return result is ExistenceFlag;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> getRequest(string requestID)
	{
		var cmd = "DPS_TEST 1,2,3";
		return await _unitOfWork.QueryAsync<DietRequestDao>(cmd);
	}
}