using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class DrugFilter : IDrugFilter
{
	private readonly IDrugsRepository _drugRepository;
	private readonly IMapper _mapper;

	public DrugFilter(IDrugsRepository drugRepository, IMapper mapper)
	{
		_drugRepository = drugRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<DrugsItemDto>> SortLimitedAsync(IOrderBy orderBy, IPagination pagination)
	{
		var orderByEntity = _mapper.Map<OrderByDao>(orderBy);
		var paginationEntity = _mapper.Map<PaginationDao>(pagination);

		var drugs = await _drugRepository.GetPaginatedDrugAsync(orderByEntity, paginationEntity);
		return _mapper.Map<IEnumerable<DrugsItemDto>>(drugs);
	}
}