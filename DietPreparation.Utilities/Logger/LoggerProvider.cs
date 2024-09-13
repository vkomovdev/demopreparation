using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DietPreparation.Utilities.Logger;
public static class LoggerProvider
{
	public static IServiceCollection RegisterDietPreparationLoggingProvider<T>(this IServiceCollection services, IConfiguration configuration) where T : class
	{
		services.AddSingleton<IDietPreparationLogger, DietPreparationLogger>();

		services.AddLogging(loggingBuilder =>
		{

			var loggingOptions = configuration.GetSection("Log4NetCore").Get<Log4NetProviderOptions>();
			loggingBuilder.AddLog4Net(loggingOptions);

		});

		return services;
	}
}
