using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Premixes;

internal class PremixReader : IPremixReader
{
	private readonly IPremixRepository _premixRepository;
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IDietRequestPremixRepository _dietRequestPremixRepository;
	private readonly IMapper _mapper;

	public PremixReader(IPremixRepository premixRepository, IDietRequestRepository dietRequestRepository, IDietRequestPremixRepository dietRequestPremixRepository, IMapper mapper)
	{
		_premixRepository = premixRepository;
		_dietRequestRepository = dietRequestRepository;
		_dietRequestPremixRepository = dietRequestPremixRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<DietRequestPremixDto>> ReadByRequestIdAsync(int requestId)
	{
		var result = await _dietRequestPremixRepository.ReadByRequestIdAsync(requestId);

		return _mapper.Map<IEnumerable<DietRequestPremixDto>>(result);
	}

	public async Task<IEnumerable<PwoPremixDto>> ReadPwoAsync()
	{
		var premixDaos = await _premixRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<PwoPremixDto>>(premixDaos);
	}

	public async Task<IEnumerable<MedicatedPremixDto>> ReadAllAsync() => _mapper.Map<IEnumerable<MedicatedPremixDto>>(await _dietRequestRepository.ReadMedicatedPremixesAsync());

	public async Task<MedicatedPremixDto> ReadAsync(int requestId) => _mapper.Map<MedicatedPremixDto>(await _dietRequestRepository.ReadMedicatedPremixAsync(requestId));

	public async ValueTask<bool> IsAllProcessedAsync(int requestId)
	{
		var hasPremix = await _dietRequestRepository.HasPremixAsync(requestId);

		if (!hasPremix)
		{
			return true;
		}

		var premixes = await _premixRepository.ReadPremixes(requestId);

		if (premixes is null)
		{
			return true;
		}

		foreach (var premix in premixes)
		{
			var premixLock = await _premixRepository.IsPremixLockedAsync(premix.PREMIX_ID);
			if (!premixLock)
			{
				return false;
			}
		}

		return true;
	}
}
