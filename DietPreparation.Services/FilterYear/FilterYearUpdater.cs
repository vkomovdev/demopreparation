using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Services.FilterYear;
public class FilterYearUpdater : IFilterYearUpdater
{
	private readonly IFilterYearRepository _filterYearRepository;

	public FilterYearUpdater(IFilterYearRepository filterYearRepository)
	{
		_filterYearRepository = filterYearRepository;
	}

	public async Task<int> UpdateAsync(int filterYear)
	{
		await _filterYearRepository.UpdateAsync(filterYear);

		return filterYear;
	}
}
