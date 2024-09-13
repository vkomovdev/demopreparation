namespace DietPreparation.Common.Interfaces;

public interface ICommonInsert<T, U>
{
	Task<U> InsertAsync(T entity);
}