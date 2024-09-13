namespace DietPreparation.Web.Configurations;

internal static class ConfigurationBuilderExtensions
{
	public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder configurationBuilder, IHostEnvironment hostingEnvironment)
	{
		return configurationBuilder
			.AddJsonFile("appsettings.json", true, true)
			.AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true, true)
			.AddEnvironmentVariables();
	}
}
