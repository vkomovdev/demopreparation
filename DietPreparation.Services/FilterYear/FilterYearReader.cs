using DietPreparation.Repositories.Spaces.Interfaces;

namespace DietPreparation.Services.FilterYear;
public class FilterYearReader : IFilterYearReader
{
	private readonly IFilterYearRepository _filterYearRepository;

	public FilterYearReader(IFilterYearRepository filterYearRepository)
	{
		_filterYearRepository = filterYearRepository;
	}
	public async Task<int> ReadAsync() => await _filterYearRepository.ReadAsync();
}
