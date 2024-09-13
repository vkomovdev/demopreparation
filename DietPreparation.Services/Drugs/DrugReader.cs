using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class DrugReader : IDrugReader
{
	private readonly IDrugsRepository _drugRepository;
	private readonly IDietRequestDrugRepository _dietRequestDrugRepository;
	private readonly IMapper _mapper;

	public DrugReader(IDrugsRepository drugRepository, IDietRequestDrugRepository dietRequestDrugRepository, IMapper mapper)
	{
		_drugRepository = drugRepository;
		_dietRequestDrugRepository = dietRequestDrugRepository;
		_mapper = mapper;
	}

	public async Task<DrugDto> ReadAsync(int id)
	{
		var drugDao = await _drugRepository.ReadAsync(id);

		return _mapper.Map<DrugDto>(drugDao);
	}

	public async Task<IEnumerable<DrugDto>> ReadAllAsync()
	{
		var drugDaos = await _drugRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<DrugDto>>(drugDaos);
	}

	public async Task<IEnumerable<DietRequestDrugDto>> ReadByRequestIdAsync(int requestId)
	{
		var result = await _dietRequestDrugRepository.ReadByRequestIdAsync(requestId);

		return _mapper.Map<IEnumerable<DietRequestDrugDto>>(result);
	}

	public async Task<IEnumerable<DrugsItemDto>> ReadPaginatedAsync(IOrderBy? orderBy, IPagination? pagination)
	{
		var orderByEntity = _mapper.Map<OrderByDao>(orderBy);
		var paginationEntity = _mapper.Map<PaginationDao>(pagination);
		
		var drugs = await _drugRepository.GetPaginatedDrugAsync(orderByEntity, paginationEntity);
		return _mapper.Map<IEnumerable<DrugsItemDto>>(drugs);
	}
}