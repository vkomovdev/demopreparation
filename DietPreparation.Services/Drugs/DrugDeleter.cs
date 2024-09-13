using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class DrugDeleter : IDrugDeleter
{
	private readonly IDietRequestDrugRepository _dietRequestDrugRepository;
	private readonly IMapper _mapper;

	public DrugDeleter(
		IDietRequestDrugRepository dietRequestDrugRepository,
		IMapper mapper)
	{
		_dietRequestDrugRepository = dietRequestDrugRepository;
		_mapper = mapper;
	}

	public async Task<int> DeleteByRequestIdAsync(int requestId)
	{
		return await _dietRequestDrugRepository.DeleteByRequestIdAsync(requestId);
	}
}
