namespace DietPreparation.Repositories.Common.Interfaces;

public interface ICloneRecord<T, U>
{
	ValueTask<U> CloneAsync(T id);
}