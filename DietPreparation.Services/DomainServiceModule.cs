using DietPreparation.Common.Configurations;
using DietPreparation.Services.AuditLogs;
using DietPreparation.Services.BasalDiets;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.Customers;
using DietPreparation.Services.DietRequests;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.Drugs;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Services.ExternalFeeds;
using DietPreparation.Services.FeedLabels;
using DietPreparation.Services.FeedLabels.Interfaces;
using DietPreparation.Services.FeedStuffs;
using DietPreparation.Services.FeedStuffs.Interfaces;
using DietPreparation.Services.FilterYear;
using DietPreparation.Services.Ingredient;
using DietPreparation.Services.InternalFeeds;
using DietPreparation.Services.Locations;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Services.Premixes;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Services.PWOs;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Services.Samples;
using DietPreparation.Services.Samples.Interfaces;
using DietPreparation.Services.Tests;
using DietPreparation.Services.Tests.Interfaces;
using DietPreparation.Services.Users;
using DietPreparation.Services.Users.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietPreparation.Services;

public class DomainServiceModule : IServiceInstaller
{
	public void Install(IServiceCollection services, IConfiguration configuration)
	{
		services.MapperRegister(GetType().Assembly);

		RegisterCustomerServices(services);
		RegisterUserServices(services);
		RegisterPwoServices(services);
		RegisterDrugServices(services);
		RegisterPremixServices(services);
		RegisterSampleServices(services);
		RegisterLocationServices(services);
		RegisterBasalDietServices(services);
		RegisterDietRequestServices(services);
		RegisterFeedStuffServices(services);
		RegisterInternalFeedServices(services);
		RegisterExternalFeedServices(services);
		RegisterTestServices(services);
		RegisterIngredientServices(services);
		RegisterFeedLabelServices(services);
		RegisterAuditServices(services);
		RegisterFilterYearServices(services);
	}

	private static void RegisterFilterYearServices(IServiceCollection services)
	{
		services.AddScoped<IFilterYearReader, FilterYearReader>();
		services.AddScoped<IFilterYearUpdater, FilterYearUpdater>();
	}
	private static void RegisterCustomerServices(IServiceCollection services)
	{
		services.AddScoped<ICustomerFinder, CustomerFinder>();
		services.AddScoped<ICustomerReader, CustomerReader>();
		services.AddScoped<ICustomerUpdater, CustomerUpdater>();
	}

	private static void RegisterPwoServices(IServiceCollection services)
	{
		services.AddScoped<IPwoReader, PwoReader>();
		services.AddScoped<IPwoCreator, PwoCreator>();
		services.AddScoped<IPwoCloser, PwoCloser>();
		services.AddScoped<IPwoConfirm, PwoConfirm>();
	}

	private static void RegisterUserServices(IServiceCollection services)
	{
		services.AddScoped<IUserUpdater, UserUpdater>();
		services.AddScoped<IUserReader, UserReader>();
	}

	private static void RegisterDrugServices(IServiceCollection services)
	{
		services.AddScoped<IDrugCreator, DrugCreator>();
		services.AddScoped<IDrugReader, DrugReader>();
		services.AddScoped<IDrugUpdater, DrugUpdater>();
		services.AddScoped<IDrugDeleter, DrugDeleter>();
		services.AddScoped<IDrugFilter, DrugFilter>();
		services.AddScoped<IDrugService, DrugService>();
	}

	private static void RegisterLocationServices(IServiceCollection services)
	{
		services.AddScoped<ILocationCreator, LocationCreator>();
		services.AddScoped<ILocationReader, LocationReader>();
		services.AddScoped<ILocationUpdater, LocationUpdater>();
		services.AddScoped<ILocationFilter, LocationFilter>();
	}

	private static void RegisterPremixServices(IServiceCollection services)
	{
		services.AddScoped<IPremixCreator, PremixCreator>();
		services.AddScoped<IPremixReader, PremixReader>();
		services.AddScoped<IPremixDeleter, PremixDeleter>();
		services.AddScoped<IPremixService, PremixService>();
	}

	private static void RegisterSampleServices(IServiceCollection services)
	{
		services.AddScoped<ISampleCreator, SampleCreator>();
		services.AddScoped<ISampleReader, SampleReader>();
		services.AddScoped<ISampleDeleter, SampleDeleter>();
		services.AddScoped<ISampleService, SampleService>();
	}

	private static void RegisterBasalDietServices(IServiceCollection services)
	{
		services.AddScoped<IBasalDietUpserter, BasalDietUpserter>();
		services.AddScoped<IBasalDietReader, BasalDietReader>();
		services.AddScoped<IBasalDietFilter, BasalDietFilter>();
	}

	private static void RegisterDietRequestServices(IServiceCollection services)
	{
		services.AddScoped<IDietRequestCreator, DietRequestCreator>();
		services.AddScoped<IDietRequestReader, DietRequestReader>();
		services.AddScoped<IDietRequestUpdater, DietRequestUpdater>();
		services.AddScoped<IDietRequestDeleter, DietRequestDeleter>();
		services.AddScoped<IDietRequestActivator, DietRequestActivator>();
		services.AddScoped<IDietRequestFilter, DietRequestFilter>();
		services.AddScoped<IDietRequestLocker, DietRequestLocker>();
		services.AddScoped<IDietRequestCloner, DietRequestCloner>();
	}

	private static void RegisterFeedStuffServices(IServiceCollection services)
	{
		services.AddScoped<IFeedStuffReader, FeedStuffReader>();
		services.AddScoped<IFeedStuffUpdater, FeedStuffUpdater>();
		services.AddScoped<IFeedStuffFilter, FeedStuffFilter>();
	}

	private static void RegisterInternalFeedServices(IServiceCollection services)
	{
		services.AddScoped<IInternalFeedReader, InternalFeedReader>();
	}

	private static void RegisterExternalFeedServices(IServiceCollection services)
	{
		services.AddScoped<IExternalFeedReader, ExternalFeedReader>();
	}

	private static void RegisterTestServices(IServiceCollection services)
	{
		services.AddScoped<ITestService, TestService>();
	}

	private static void RegisterIngredientServices(IServiceCollection services)
	{
		services.AddScoped<IIngredientReader, IngredientReader>();
	}

	private static void RegisterFeedLabelServices(IServiceCollection services)
	{
		services.AddScoped<IFeedLabelReader, FeedLabelReader>();
		services.AddScoped<IFeedLabelParser, FeedLabelParser>();
		services.AddScoped<IFeedLabelBuilder, FeedLabelBuilder>();
		services.AddScoped<IFeedLabelPrinter, FeedLabelPrinter>();
		services.AddScoped<IFeedLabelCreator, FeedLabelCreator>();
	}

	private static void RegisterAuditServices(IServiceCollection services)
	{
		services.AddScoped<IAuditFilter, AuditFilter>();
		services.AddScoped<IAuditReader, AuditReader>();
		services.AddScoped<IAuditCreator, AuditCreator>();
	}
}