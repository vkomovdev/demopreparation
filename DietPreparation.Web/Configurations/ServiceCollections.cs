using DietPreparation.Application;
using DietPreparation.Common.Configurations;
using DietPreparation.Data;
using DietPreparation.Filter;
using DietPreparation.Repositories;
using DietPreparation.Security;
using DietPreparation.Services;
using DietPreparation.Web.Options;
using Microsoft.Extensions.Options;

namespace DietPreparation.Web.Configurations;

internal static class ServiceCollections
{
	public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<ApplicationOptions>(configuration)
			.AddSingleton(x => x.GetRequiredService<IOptions<ApplicationOptions>>().Value);
	}

	public static void AddModules(this IServiceCollection services)
	{
		services.AddScoped<IServiceInstaller, ApplicationModule>();
		services.AddScoped<IServiceInstaller, DomainRepositoryModule>();
		services.AddScoped<IServiceInstaller, DomainServiceModule>();
		services.AddScoped<IServiceInstaller, DataModule>();
		services.AddScoped<IServiceInstaller, FilterModule>();
		services.AddScoped<IServiceInstaller, SecurityModule>();
	}
}