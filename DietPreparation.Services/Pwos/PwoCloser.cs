using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;

namespace DietPreparation.Services.PWOs;

public class PwoCloser : IPwoCloser
{
	private readonly IPwoRepository _pwoRepository;

	public PwoCloser(IPwoRepository pwoRepository)
	{
		_pwoRepository = pwoRepository;
	}

	public async Task CloseAsync(PwoCloseDto model)
	{
		await _pwoRepository.ClosePWOAsync(model);
	}
}
