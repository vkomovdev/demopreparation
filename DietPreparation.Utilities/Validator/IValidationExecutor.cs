namespace DietPreparation.Utilities.Validator;

public interface IValidationExecutor<T>
{
	void Execute(T parameter);
}