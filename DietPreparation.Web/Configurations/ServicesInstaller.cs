using DietPreparation.Common.Configurations;
using DietPreparation.Common.Extensions;
using System.Reflection;

namespace DietPreparation.Web.Configurations;

public static class ServicesInstaller
{
	public static IServiceCollection InstallServices(this IServiceCollection services, IConfiguration configuration, params Assembly[] assemblies)
	{
		IEnumerable<IServiceInstaller> serviceInstallers = assemblies
			.SelectMany(x => x.DefinedTypes)
			.Where(TypeInfoExtensions.IsAssignableToType<IServiceInstaller>)
			.Select(Activator.CreateInstance)
			.Cast<IServiceInstaller>();

		foreach (IServiceInstaller installer in serviceInstallers)
		{
			installer.Install(services, configuration);
		}

		return services;
	}
}
