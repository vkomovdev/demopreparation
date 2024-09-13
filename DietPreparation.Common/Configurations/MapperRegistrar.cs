using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DietPreparation.Common.Configurations;

public static class MapperRegistrar
{
	public static void MapperRegister(this IServiceCollection services, Assembly assembly)
	{
		var config = TypeAdapterConfig.GlobalSettings;
		config.Scan(assembly);

		services.AddSingleton(config);
		services.AddScoped<IMapper, ServiceMapper>();
	}
}
