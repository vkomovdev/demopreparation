namespace DietPreparation.Common.Interfaces;

public interface ICommonUpdate<T>
{
	Task<T> UpdateAsync(T entity);
}