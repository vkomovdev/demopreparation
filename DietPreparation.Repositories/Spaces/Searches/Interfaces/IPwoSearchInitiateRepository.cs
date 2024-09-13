using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IPwoSearchInitiateRepository : ISearchRepository<DietRequestDao>
{
	ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IPwoFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao);
}