namespace DietPreparation.Common.Interfaces;

public interface ICommonDelete<T, U>
{
	Task<U> DeleteAsync(T entity);
}