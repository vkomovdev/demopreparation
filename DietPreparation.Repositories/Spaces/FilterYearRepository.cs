using DietPreparation.Data.UnitOfWork;
using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Repositories.Spaces;
internal class FilterYearRepository: IFilterYearRepository
{
	private readonly IUnitOfWork _unitOfWork;

	public FilterYearRepository(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public async Task<int> ReadAsync()
	{
		var cmd = "SELECT TOP 1 Value FROM DP_APP_SETUP";
		return await _unitOfWork.QuerySingleAsync<int>(cmd);
	}

	public async Task<int> UpdateAsync(int filterYear)
	{
		var cmd = $"UPDATE DP_APP_SETUP SET Value = '{filterYear}'";
		return await _unitOfWork.ExecuteAsync(cmd);
	}
}
