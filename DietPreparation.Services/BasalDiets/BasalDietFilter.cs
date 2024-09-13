using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.BasalDiets;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Repositories.Spaces.Searches.Interfaces;
using DietPreparation.Services.BasalDiets.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.BasalDiets;
internal class BasalDietFilter : IBasalDietFilter
{
	private readonly ISearchesRepository _searchRepository;
	private readonly IMapper _mapper;

	public BasalDietFilter(
		ISearchesRepository searchRepository,
		IMapper mapper)
	{
		_searchRepository = searchRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<BasalDietDto>> FilterAsync(BasalDietFilterDto filter)
	{
		var filterDao = _mapper.Map<BasalDietFilterDao>(filter);
		var result = await _searchRepository.BasalDietsAsync(filterDao);

		return _mapper.Map<IEnumerable<BasalDietDto>>(result);
	}

	public async ValueTask<IEnumerable<BasalDietIngredientDto>> FilterIngredientsAsync(BasalDietIngredientFilterDto filter)
	{
		var filterDao = _mapper.Map<BasalDietIngredientFilterDao>(filter);
		var result = await _searchRepository.BasalDietIngredientsAsync(filterDao);

		return _mapper.Map<IEnumerable<BasalDietIngredientDto>>(result);
	}

	public async ValueTask<IEnumerable<BasalDietDto>> SortLimitedAsync(IOrderBy orderBy, IPagination pagination)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);
		var result = await _searchRepository.BasalDietsAsync(orderByDao, paginationDao);

		return _mapper.Map<IEnumerable<BasalDietDto>>(result);
	}
}
