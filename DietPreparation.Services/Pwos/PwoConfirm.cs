using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;

namespace DietPreparation.Services.PWOs;

public class PwoConfirm : IPwoConfirm
{
	private readonly IPwoRepository _pwoRepository;

	public PwoConfirm(IPwoRepository pwoRepository)
	{
		_pwoRepository = pwoRepository;
	}

	public async Task ConfirmAsync(PwoConfirmDto model)
	{
		await _pwoRepository.ConfirmPWO(model.PwoId.ToString(), model.Type.GetDisplayName());
	}
}