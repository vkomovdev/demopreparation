using DietPreparation.Filter.Options;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface ISearchRepository<T> where T : class
{
	ValueTask<IEnumerable<T>> SearchAsync(IOrderByDao orderByDao, IPagination paginationDao);
}