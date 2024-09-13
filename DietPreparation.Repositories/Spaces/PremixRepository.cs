using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;
internal class PremixRepository : IPremixRepository
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly QueryFactory _queryFactory;

	public PremixRepository(IUnitOfWork unitOfWork, QueryFactory queryFactory)
	{
		_unitOfWork = unitOfWork;
		_queryFactory = queryFactory;
	}
	public async Task AuditPreMixUpdate(string iAuditLogNumber,
								string sPreMix,
								string sPreMixAmount,
								string sPreMixUOM,
								string sPreMixWeightYN)
	{

		// CREATE ARRAYS CONTAINING THE REQUEST PREMIX INFORMATION
		var aPreMix = sPreMix.Split(",");
		var aPreMixAmount = sPreMixAmount.Split(",");
		var aPreMixUOM = sPreMixUOM.Split(",");
		var aPreMixWeightYN = sPreMixWeightYN.Split(",");
		var lenPreMix = aPreMix.Length;

		for (var i = 0; i < lenPreMix; i++)
		{
			var cmd =
				$"""
				 DPS_LOG_TO_AUDIT_PREMIX {iAuditLogNumber}, 
				 '{aPreMix[i]}', 
				 {aPreMixAmount[i]}, 
				 '{aPreMixUOM[i]}', 
				 {aPreMixWeightYN[i]}
				 """;
			await _unitOfWork.ExecuteAsync(cmd);
		}
	}

	public async Task UpdatePreMixUsed(string sRequest)
	{
		var cmd = $"DPS_REQUEST_UPDATE_PREMIX_USED {sRequest}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async Task UpdatePreMixActive(string sRequest)
	{
		var cmd = $"DPS_REQUEST_UPDATE_PREMIX_ACTIVE {sRequest}";
		await _unitOfWork.ExecuteAsync(cmd);
	}

	public async ValueTask<IEnumerable<PremixDao>> ReadPremixes(int requestId)
	{
		var cmd = $"SELECT PREMIX_ID FROM DP_REQUEST_PREMIX WHERE REQUEST_ID = {requestId}";
		return await _unitOfWork.QueryAsync<PremixDao>(cmd);
	}

	public async ValueTask<bool> IsPremixLockedAsync(int premixId)
	{
		//Premix can be like request
		var cmd = $"SELECT LOCK FROM DP_REQUEST WHERE REQUEST_ID = {premixId}";

		return await _unitOfWork.QueryFirstAsync<bool>(cmd);

	}

	public async ValueTask<IEnumerable<PwoPremixDao>> ReadAllAsync()
	{
		string sql = await _queryFactory.BuildReadPremixesQuery();
		return await _unitOfWork.QueryAsync<PwoPremixDao>(sql);
	}
}
