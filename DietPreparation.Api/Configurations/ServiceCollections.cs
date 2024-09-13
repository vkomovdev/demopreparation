using DietPreparation.Common.Configurations;
using DietPreparation.Data;
using DietPreparation.Repositories;
using DietPreparation.Services;
using DietPreparation.ServicesApi.Options;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace DietPreparation.ServicesApi.Configurations;

internal static class ServiceCollections
{
	public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<ApplicationOptions>(configuration)
			.AddSingleton(x => x.GetRequiredService<IOptions<ApplicationOptions>>().Value);
	}

	public static void AddCustomSwagger(this IServiceCollection services, string buildVersion)
	{
		services.AddSwaggerGen(c =>
		{
			c.CustomSchemaIds(type => type.ToString());
			c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Diet Preparation", Version = buildVersion });
		});
	}

	public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
	{
		CorsPolicyOptions? corsPolicy = configuration.GetSection(nameof(CorsPolicyOptions)).Get<CorsPolicyOptions>();

		services.AddCors(options =>
		{
			options.AddPolicy(corsPolicy!.PolicyName,
				policy =>
				{
					policy.WithOrigins(corsPolicy.Origins.Replace(" ", string.Empty).Split(','))
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
		});
	}

	public static void AddModules(this IServiceCollection services)
	{
		services.AddScoped<IServiceInstaller, DomainRepositoryModule>();
		services.AddScoped<IServiceInstaller, DomainServiceModule>();
		services.AddScoped<IServiceInstaller, DataModule>();
	}
}
