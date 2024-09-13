using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;
using DietPreparation.Services.Drugs.Interfaces;

namespace DietPreparation.Services.Drugs;

internal class DrugService : IDrugService
{
	private readonly IDrugCreator _drugCreater;
	private readonly IDrugDeleter _drugDeleter;
	private readonly IDrugReader _drugReader;
	private readonly IDrugFilter _drugFilter;

	public DrugService(
		IDrugCreator drugCreater,
		IDrugDeleter drugDeleter,
		IDrugReader drugReader,
		IDrugFilter drugFilter)
	{
		_drugCreater = drugCreater;
		_drugDeleter = drugDeleter;
		_drugReader = drugReader;
		_drugFilter = drugFilter;
	}

	public async Task<DietRequestDrugDto> CreateAsync(DietRequestDrugDto dietRequestSampleDto) => await _drugCreater.CreateAsync(dietRequestSampleDto);

	public async Task<int> DeleteByRequestIdAsync(int requestId) => await _drugDeleter.DeleteByRequestIdAsync(requestId);

	public async Task<DrugDto> ReadAsync(int id) => await _drugReader.ReadAsync(id);

	public async Task<IEnumerable<DrugDto>> ReadAllAsync() => await _drugReader.ReadAllAsync();

	public async Task<IEnumerable<DietRequestDrugDto>> ReadByRequestIdAsync(int requestId) => await _drugReader.ReadByRequestIdAsync(requestId);

	public async Task<IEnumerable<DrugsItemDto>> SortLimitedAsync(IOrderBy orderBy, IPagination pagination) => await _drugFilter.SortLimitedAsync(orderBy, pagination);
}
