using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Premixes;

internal class PremixCreator : IPremixCreator
{
	private readonly IDietRequestPremixRepository _dietRequestPremixRepository;
	private readonly IMapper _mapper;

	public PremixCreator(
		IDietRequestPremixRepository dietRequestPremixRepository,
		IMapper mapper)
	{
		_dietRequestPremixRepository = dietRequestPremixRepository;
		_mapper = mapper;
	}

	public async Task<DietRequestPremixDto> CreateAsync(DietRequestPremixDto dietRequestPremixDto)
	{
		dietRequestPremixDto.Id = await _dietRequestPremixRepository.InsertAsync(
			_mapper.Map<DietRequestPremixDao>(dietRequestPremixDto));

		return dietRequestPremixDto;
	}
}
