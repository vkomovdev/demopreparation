using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.DietRequests.Interfaces;

namespace DietPreparation.Services.DietRequests;
internal class DietRequestLocker : IDietRequestLocker
{
	private readonly IDietRequestRepository _dietRequestRepository;

	public DietRequestLocker(IDietRequestRepository dietRequestRepository)
	{
		_dietRequestRepository = dietRequestRepository;
	}

	public async Task LockRequestTableAsync(int premixId)
	{
		await _dietRequestRepository.LockRequestAsync(premixId);
	}
}
