namespace DietPreparation.Web.Configurations;

internal static class HostBuilderExtensions
{
	public static IWebHostBuilder ConfigureAppConfiguration(this IWebHostBuilder builder)
	{
		return builder.ConfigureAppConfiguration(
			(hostingContext, config) =>
				config.AddConfiguration(hostingContext.HostingEnvironment));
	}
}