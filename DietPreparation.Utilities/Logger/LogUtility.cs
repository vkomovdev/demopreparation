using log4net;
using System.Reflection;

namespace DietPreparation.Utilities.Logger;

public class DietPreparationLogger : IDietPreparationLogger
{
	private readonly ILog _logger;

	public DietPreparationLogger()
	{
		_logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);
	}

	public void Debug(string message)
	{
		_logger?.Debug(message);
	}

	public void Info(string message)
	{
		_logger?.Info(message);
	}

	public void Error(string message, Exception? ex = null)
	{
		_logger?.Error(message, ex?.InnerException);
	}
}
