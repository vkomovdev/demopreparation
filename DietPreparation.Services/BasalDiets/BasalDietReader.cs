using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.BasalDiets.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.BasalDiets;

internal class BasalDietReader : IBasalDietReader
{
	private readonly IBasalDietRepository _basalDietRepository;
	private readonly IDietRequestBasalDietRepository _dietRequestBasalDietRepository;
	private readonly IMapper _mapper;

	public BasalDietReader(
		IBasalDietRepository basalDietRepository,
		IDietRequestBasalDietRepository dietRequestBasalDietRepository,
		IMapper mapper)
	{
		_basalDietRepository = basalDietRepository;
		_dietRequestBasalDietRepository = dietRequestBasalDietRepository;
		_mapper = mapper;
	}

	public async Task<BasalDietDto> ReadAsync(int id)
	{
		var basalDietDao = await _basalDietRepository.ReadAsync(id.ToString());
		return _mapper.Map<BasalDietDto>(basalDietDao);
	}

	public async Task<IEnumerable<BasalDietDto>> ReadAllAsync()
	{
		var result = await _basalDietRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<BasalDietDto>>(result);
	}

	public async Task<DietRequestBasalDietDto> ReadByRequestIdAsync(int requestId)
	{
		var dietRequestBasalDiet = _mapper.Map<DietRequestBasalDietDto>(
			await _dietRequestBasalDietRepository.ReadByRequestIdAsync(requestId));

		if (dietRequestBasalDiet.BasalDietId.HasValue)
		{
			var basalDiet = await ReadAsync(dietRequestBasalDiet.BasalDietId.Value);
			_mapper.Map(basalDiet, dietRequestBasalDiet);
		}
		return dietRequestBasalDiet;
	}

	public async Task<int> ReadRecordIdByRequestIdAsync(int requestId)
		=> await _dietRequestBasalDietRepository.ReadRecordIdByRequestIdAsync(requestId);
}
