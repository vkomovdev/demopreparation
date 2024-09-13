using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;

namespace DietPreparation.Services.PWOs;

public class PwoCreator : IPwoCreator
{
	private readonly IPwoRepository _pwoRepository;

	public PwoCreator(IPwoRepository pwoRepository)
	{
		_pwoRepository = pwoRepository;
	}

	public async Task CreateWorkOrderAsync(CreateBatchDto model)
	{
		await _pwoRepository.InsertBatchAsync(model);
	}
}
