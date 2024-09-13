using DietPreparation.Models.DTO;
using DietPreparation.Services.Premixes.Interfaces;

namespace DietPreparation.Services.Premixes;

internal class PremixService : IPremixService
{
	private readonly IPremixCreator _premixCreater;
	private readonly IPremixDeleter _premixDeleter;
	private readonly IPremixReader _premixReader;

	public PremixService(
		IPremixCreator premixCreater,
		IPremixDeleter premixDeleter,
		IPremixReader premixReader)
	{
		_premixCreater = premixCreater;
		_premixDeleter = premixDeleter;
		_premixReader = premixReader;
	}

	public async Task<DietRequestPremixDto> CreateAsync(DietRequestPremixDto entity) => await _premixCreater.CreateAsync(entity);

	public async Task<MedicatedPremixDto> ReadAsync(int id) => await _premixReader.ReadAsync(id);

	public async Task<IEnumerable<MedicatedPremixDto>> ReadAllAsync() => await _premixReader.ReadAllAsync();

	public async Task<IEnumerable<PwoPremixDto>> ReadPwoAsync() => await _premixReader.ReadPwoAsync();

	public async Task<IEnumerable<DietRequestPremixDto>> ReadByRequestIdAsync(int requestId) => await _premixReader.ReadByRequestIdAsync(requestId);

	public async Task<int> DeleteByRequestIdAsync(int requestId) => await _premixDeleter.DeleteByRequestIdAsync(requestId);

	public async ValueTask<bool> IsAllProcessedAsync(int requestId) => await _premixReader.IsAllProcessedAsync(requestId);
}
