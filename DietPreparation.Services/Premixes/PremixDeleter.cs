using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Premixes;

internal class PremixDeleter : IPremixDeleter
{
	private readonly IDietRequestPremixRepository _dietRequestPremixRepository;
	private readonly IMapper _mapper;

	public PremixDeleter(
		IDietRequestPremixRepository dietRequestPremixRepository,
		IMapper mapper)
	{
		_dietRequestPremixRepository = dietRequestPremixRepository;
		_mapper = mapper;
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
	{
		return await _dietRequestPremixRepository.DeleteByRequestIdAsync(requestId);
	}
}
