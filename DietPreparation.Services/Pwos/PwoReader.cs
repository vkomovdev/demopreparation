using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.PWOs;

public class PwoReader : IPwoReader
{
	private readonly IPwoRepository _pwoRepository;
	private readonly IMapper _mapper;

	public PwoReader(IPwoRepository pwoRepository, IMapper mapper)
	{
		_pwoRepository = pwoRepository;
		_mapper = mapper;
	}
	public async ValueTask<PwoHeaderDto> ReadHeaderAsync(int requestId, int sequence)
	{
		var header = await _pwoRepository.ReadPwoHeaderAsync(requestId, sequence);
		return _mapper.Map<PwoHeaderDto>(header);
	}

	public async ValueTask<IEnumerable<PwoDrugDto>> ReadDrugsAsync(int sequence)
	{
		var drugs = await _pwoRepository.ReadPwoDrugsAsync(sequence);
		return drugs.Select(_mapper.Map<PwoDrugDto>);
	}

	public async ValueTask<IEnumerable<PwoPremixDrugDto>> ReadPremixDrugsAsync(int sequence)
	{
		var drugs = await _pwoRepository.ReadPwoPremixDrugsAsync(sequence);
		return drugs.Select(_mapper.Map<PwoPremixDrugDto>);
	}

	public async ValueTask<IEnumerable<PwoIngredientDto>> ReadIngredientsAsync(int pwoId)
	{
		var ingredients = await _pwoRepository.ReadPwoIngredientsAsync(pwoId);
		return ingredients.Select(_mapper.Map<PwoIngredientDto>);
	}

	public async ValueTask<IEnumerable<PwoPremixDto>> ReadPremixesAsync(int pwoId)
	{
		var premixes = await _pwoRepository.ReadPwoPremixesAsync(pwoId);
		return premixes.Select(_mapper.Map<PwoPremixDto>);
	}
	public async ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllAsync(int requestId)
	{
		var pwos = await _pwoRepository.ReadPwoSelectAllAsync(requestId);
		return pwos.Select(_mapper.Map<PwoSelectAllDto>);
	}

	public async ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllForLabelOpenAsync(int requestId)
	{
		var pwos = await _pwoRepository.ReadPwoSelectAllForLabelOpenAsync(requestId);
		return pwos.Select(_mapper.Map<PwoSelectAllDto>);
	}

	public async ValueTask<IEnumerable<PwoSelectAllDto>> ReadPwoSelectAllForLabelReprintAsync(int requestId)
	{
		var pwos = await _pwoRepository.ReadPwoSelectAllForLabelReprintAsync(requestId);
		return pwos.Select(_mapper.Map<PwoSelectAllDto>);
	}
}