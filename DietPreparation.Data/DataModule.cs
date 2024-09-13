using DietPreparation.Common.Configurations;
using DietPreparation.Data.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Data.SqlClient;

namespace DietPreparation.Data;

public class DataModule : IServiceInstaller
{
	private const string ConnectionStringOption = "ConnectionString:DefaultConnection";

	public void Install(IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<DbConnection>(_ => new SqlConnection(configuration[ConnectionStringOption]));
		services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
	}
}