using DietPreparation.Filter.Options;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DAO.FilterOptions;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IFeedStuffSearchRepository : ISearchRepository<FeedStuffReportDao>
{
	ValueTask<IEnumerable<FeedStuffReportDao>> SearchAsync(IFeedStuffFilter filterDao, IOrderByDao orderByDao, IPagination paginationDao);
}