using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class DrugCreator : IDrugCreator
{
	private readonly IDietRequestDrugRepository _dietRequestDrugRepository;
	private readonly IMapper _mapper;

	public DrugCreator(
		IDietRequestDrugRepository dietRequestDrugRepository,
		IMapper mapper)
	{
		_dietRequestDrugRepository = dietRequestDrugRepository;
		_mapper = mapper;
	}

	public async Task<DietRequestDrugDto> CreateAsync(DietRequestDrugDto dietRequestDrugDto)
	{
		dietRequestDrugDto.Id = await _dietRequestDrugRepository.InsertAsync(
			_mapper.Map<DietRequestDrugDao>(dietRequestDrugDto));

		return dietRequestDrugDto;
	}
}
