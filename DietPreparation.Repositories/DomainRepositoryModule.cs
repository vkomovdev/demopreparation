using DietPreparation.Common.Configurations;
using DietPreparation.Repositories.Queries;
using DietPreparation.Repositories.Spaces;
using DietPreparation.Repositories.Spaces.DietRequests;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Repositories.Spaces.Searches;
using DietPreparation.Repositories.Spaces.Searches.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietPreparation.Repositories;

public class DomainRepositoryModule : IServiceInstaller
{
	public void Install(IServiceCollection services, IConfiguration configuration)
	{
		services.MapperRegister(GetType().Assembly);

		RegisterRepositories(services);
		RegisterSearchRepositories(services);
	}

	private static void RegisterRepositories(IServiceCollection services)
	{
		services.AddScoped<QueryFactory>();
		services.AddScoped<DietRequestQueryFactory>();
		services.AddScoped<IDietRequestRepository, DietRequestRepository>();
		services.AddScoped<ILocationRepository, LocationRepository>();
		services.AddScoped<IDrugsRepository, DrugsRepository>();
		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<IBasalDietRepository, BasalDietRepository>();
		services.AddScoped<IAuditRepository, AuditRepository>();
		services.AddScoped<IFeedStuffRepository, FeedStuffRepository>();
		services.AddScoped<IPremixRepository, PremixRepository>();
		services.AddScoped<IPwoRepository, PwoRepository>();
		services.AddScoped<ITestRepository, TestRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IDietRequestBasalDietRepository, DietRequestBasalDietRepository>();
		services.AddScoped<IDietRequestDrugRepository, DietRequestDrugRepository>();
		services.AddScoped<IDietRequestExternalFeedRepository, DietRequestExternalFeedRepository>();
		services.AddScoped<IDietRequestInternalFeedRepository, DietRequestInternalFeedRepository>();
		services.AddScoped<IDietRequestPremixRepository, DietRequestPremixRepository>();
		services.AddScoped<IDietRequestSampleRepository, DietRequestSampleRepository>();
		services.AddScoped<IIngredientRepository, IngredientRepository>();
		services.AddScoped<IFeedLabelRepository, FeedLabelRepository>();
		services.AddScoped<IFilterYearRepository, FilterYearRepository>();
	}

	private static void RegisterSearchRepositories(IServiceCollection services)
	{
		services.AddScoped<IDietRequestSearchRepository, DietRequestSearchRepository>();
		services.AddScoped<IFeedLabelSearchRepository, FeedLabelSearchRepository>();
		services.AddScoped<IFeedStuffSearchRepository, FeedStuffSearchRepository>();
		services.AddScoped<IPwoSearchCloseRepository, PwoClosedSearchRepository>();
		services.AddScoped<IPwoSearchInitiateRepository, PwoInitiatedSearchRepository>();
		services.AddScoped<IPwoSearchRepository, PwoDietRequestRepository>();
		services.AddScoped<IBasalDietSearchRepository, BasalDietSearchRepository>();
		services.AddScoped<IAuditSearchRepository, AuditSearchRepository>();
		services.AddScoped<ISearchesRepository, SearchesRepository>();
	}
}
