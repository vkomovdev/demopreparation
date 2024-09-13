using DietPreparation.Filter.Options;

namespace DietPreparation.Filter.Interfaces;

public interface IFilterLimited<T, U, Y> where U : IFilterBy where Y : IPagination
{
	ValueTask<IEnumerable<T>> FilterLimitedAsync(U filter, Y pagination);
}