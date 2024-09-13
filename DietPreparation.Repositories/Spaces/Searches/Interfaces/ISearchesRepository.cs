using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO.TableOptions;

namespace DietPreparation.Repositories.Spaces.Searches.Interfaces;

public interface ISearchesRepository
{
	ValueTask<IEnumerable<DietRequestDao>> PwoInitiateAsync(OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<DietRequestDao>> PwoCloseAsync(OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(PwoFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(FeedLabelFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<DietRequestDao>> DietRequestsAsync(DietRequestFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<DietRequestTinyDao>> DietRequestsAsync(DietRequestTinyFilterDao filterDao);


	ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(BasalDietFilterDao filterDao);
	ValueTask<IEnumerable<BasalDietDao>> BasalDietsAsync(OrderByDao orderByDao, PaginationDao paginationDao);
	ValueTask<IEnumerable<BasalDietIngredientDao>> BasalDietIngredientsAsync(BasalDietIngredientFilterDao filterDao);

	ValueTask<IEnumerable<AuditItemDao>> AuditsAsync(AuditFilterDao filterDao, OrderByDao orderByDao, PaginationDao paginationDao);
}