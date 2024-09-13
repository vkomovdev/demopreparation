using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface IFilterSorted<T, U, Y, Z> where U : IFilterBy where Y : IOrderBy where Z : IPagination
{
	ValueTask<IEnumerable<T>> FilterSortedAsync(U filter, Y orderBy, Z pagination);
}