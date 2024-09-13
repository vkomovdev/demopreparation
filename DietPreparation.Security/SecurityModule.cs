using DietPreparation.Common.Configurations;
using DietPreparation.Security.Authentications;
using DietPreparation.Security.Authentications.Interfaces;
using DietPreparation.Security.Authorizations;
using DietPreparation.Security.Authorizations.Interfaces;
using DietPreparation.Security.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DietPreparation.Security;

public class SecurityModule : IServiceInstaller
{
	public void Install(IServiceCollection services, IConfiguration configuration)
	{
		services.MapperRegister(GetType().Assembly);
		services.AddHttpContextAccessor();
		services.AddScoped<IAuthorizationService, AuthorizationService>();
		services.AddScoped<IUserSecurityService, UserSecurityService>();
		services.AddScoped<IAuthContextAccessor, AuthContextAccessor>();

		services.Configure<ApplicationOptions>(configuration)
			.AddSingleton(x => x.GetRequiredService<IOptions<ApplicationOptions>>().Value);
	}
}