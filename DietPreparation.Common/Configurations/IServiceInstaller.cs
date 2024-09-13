using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietPreparation.Common.Configurations;

public interface IServiceInstaller
{
	void Install(IServiceCollection services, IConfiguration configuration);
}
