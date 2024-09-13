using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.DietRequests.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;

internal class DietRequestActivator : IDietRequestActivator
{
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IMapper _mapper;

	public DietRequestActivator(
		IDietRequestRepository dietRequestRepository,
		IMapper mapper)
	{
		_dietRequestRepository = dietRequestRepository;
		_mapper = mapper;
	}

	public async Task<bool> ActivateAsync(int requestId)
		=> await _dietRequestRepository.ActivateAsync(requestId);
}