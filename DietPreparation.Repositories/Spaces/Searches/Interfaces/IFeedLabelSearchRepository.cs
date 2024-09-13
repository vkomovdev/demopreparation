using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IFeedLabelSearchRepository : ISearchRepository<DietRequestDao>
{
	ValueTask<IEnumerable<DietRequestDao>> SearchAsync(IFeedLabelFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao);
}