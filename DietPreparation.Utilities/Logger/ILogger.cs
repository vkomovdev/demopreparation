namespace DietPreparation.Utilities.Logger;

public interface IDietPreparationLogger
{
	void Debug(string message);
	void Info(string message);
	void Error(string message, Exception? ex = null);
}
