namespace DietPreparation.Common.Interfaces;

public interface ICommonUpsert<T>
{
	Task<T> UpsertAsync(T entity);
}