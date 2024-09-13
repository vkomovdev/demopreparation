using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface ISortLimited<T, U, Y> where U : IOrderBy where Y : IPagination
{
	ValueTask<IEnumerable<T>> SortLimitedAsync(U orderBy, Y pagination);
}