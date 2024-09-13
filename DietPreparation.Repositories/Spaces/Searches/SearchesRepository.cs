using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Repositories.Spaces.Searches.Interfaces;

namespace DietPreparation.Repositories.Spaces.Searches;

public class SearchesRepository : ISearchesRepository
{
	private readonly IDietRequestSearchRepository _dietRequestSearchRepository;
	private readonly IFeedLabelSearchRepository _feedLabelSearchRepository;
	private readonly IPwoSearchCloseRepository _pwoClosedSearchRepository;
	private readonly IPwoSearchInitiateRepository _pwoInitiatedSearchRepository;
	private readonly IPwoSearchRepository _pwoDietRequestRepository;
	private readonly IBasalDietSearchRepository _basalDietSearchRepository;
	private readonly IAuditSearchRepository _auditSearchRepository;

	public SearchesRepository(
		IDietRequestSearchRepository dietRequestSearchRepository,
		IFeedLabelSearchRepository feedLabelSearchRepository,
		IPwoSearchCloseRepository pwoClosedSearchRepository,
		IPwoSearchInitiateRepository pwoInitiatedSearchRepository,
		IPwoSearchRepository pwoDietRequestRepository,
		IBasalDietSearchRepository basalDietSearchRepository,
		IAuditSearchRepository auditSearchRepository
		)
	{
		_dietRequestSearchRepository = dietRequestSearchRepository;
		_feedLabelSearchRepository = feedLabelSearchRepository;
		_pwoClosedSearchRepository = pwoClosedSearchRepository;
		_pwoInitiatedSearchRepository = pwoInitiatedSearchRepository;
		_pwoDietRequestRepository = pwoDietRequestRepository;
		_basalDietSearchRepository = basalDietSearchRepository;
		_auditSearchRepository = auditSearchRepository;
	}

	public async ValueTask<IEnumerable<DietRequestDao>> PwoInitiateAsync(OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _pwoInitiatedSearchRepository.SearchAsync(orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> PwoCloseAsync(OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _pwoClosedSearchRepository.SearchAsync(orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(PwoFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _pwoDietRequestRepository.SearchAsync(filterDao, orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(FeedLabelFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _feedLabelSearchRepository.SearchAsync(filterDao, orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(DietRequestFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _dietRequestSearchRepository.SearchAsync(filterDao, orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<DietRequestTinyDao>> DietRequestsAsync(DietRequestTinyFilterDao filterDao)
	{
		return await _dietRequestSearchRepository.SearchAsync(filterDao);
	}

	public async ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _basalDietSearchRepository.SearchAsync(orderByDao, paginationDao);
	}

	public async ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(BasalDietFilterDao filterDao)
	{
		return await _basalDietSearchRepository.SearchAsync(filterDao);
	}

	public async ValueTask<IEnumerable<BasalDietIngredientDao>> BasalDietIngredientsAsync(BasalDietIngredientFilterDao filterDao)
	{
		return await _basalDietSearchRepository.SearchBasalDietIngredientsAsync(filterDao);
	}

	public async ValueTask<IEnumerable<AuditItemDao>> AuditsAsync(AuditFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao)
	{
		return await _auditSearchRepository.SearchAsync(filterDao, orderByDao, paginationDao);
	}
}