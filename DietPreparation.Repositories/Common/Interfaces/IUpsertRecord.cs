namespace DietPreparation.Repositories.Common.Interfaces;

public interface IUpsertRecord<T, U>
{
	Task<U> UpsertAsync(T entity);
}
