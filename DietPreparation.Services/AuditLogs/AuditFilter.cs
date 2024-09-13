using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Spaces.Searches.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.AuditLogs;
internal class AuditFilter : IAuditFilter
{
	private readonly ISearchesRepository _searchesRepository;
	private readonly IMapper _mapper;

	public AuditFilter(
		ISearchesRepository searchesRepository,
		IMapper mapper)
	{
		_searchesRepository = searchesRepository;
		_mapper = mapper;
	}

	public async ValueTask<IEnumerable<AuditItemDto>> FilterSortedAsync(AuditFilterDto filter, IOrderBy orderBy, IPagination pagination)
	{
		var filterDao = _mapper.Map<AuditFilterDao>(filter);
		var orderByDao = _mapper.Map<OrderByDao>(orderBy);
		var paginationDao = _mapper.Map<PaginationDao>(pagination);
		var result = await _searchesRepository.AuditsAsync(filterDao, orderByDao, paginationDao);

		return _mapper.Map<IEnumerable<AuditItemDto>>(result);
	}
}
