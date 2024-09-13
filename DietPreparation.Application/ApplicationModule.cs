using DietPreparation.Application.Handlers.CommandHandlers;
using DietPreparation.Application.Handlers.CommandHandlers.Customers;
using DietPreparation.Application.Handlers.CommandHandlers.DietRequests;
using DietPreparation.Application.Handlers.CommandHandlers.FeedLabels;
using DietPreparation.Application.Handlers.CommandHandlers.FeedStuffs;
using DietPreparation.Application.Handlers.CommandHandlers.PWOs;
using DietPreparation.Application.Handlers.CommandHandlers.Users;
using DietPreparation.Application.Handlers.QueryHandlers;
using DietPreparation.Application.Handlers.QueryHandlers.Customers;
using DietPreparation.Application.Handlers.QueryHandlers.DietRequests;
using DietPreparation.Application.Handlers.QueryHandlers.Drugs;
using DietPreparation.Application.Handlers.QueryHandlers.FeedLabels;
using DietPreparation.Application.Handlers.QueryHandlers.FeedStuffs;
using DietPreparation.Application.Handlers.QueryHandlers.PWOs;
using DietPreparation.Application.Handlers.QueryHandlers.Users;
using DietPreparation.Common.Configurations;
using DietPreparation.Utilities.Validator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DietPreparation.Application;

public class ApplicationModule : IServiceInstaller
{
	public void Install(IServiceCollection services, IConfiguration configuration)
	{
		services.MapperRegister(GetType().Assembly);
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

		services.AddValidatorsFromAssembly(GetType().Assembly);
		services.AddScoped(typeof(IValidationExecutor<>), typeof(ValidationExecutor<>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		RegisterUserHandlers(services);
		RegisterPwoHandlers(services);
		RegisterDietRequestHandlers(services);
		RegisterFeedStuffHandlers(services);
		RegisterDrugRequestHandlers(services);
		RegisterFeedLabelHandlers(services);
		RegisterCustomerHandlers(services);
		RegisterFilterYearHandlers(services);
	}

	private void RegisterDrugRequestHandlers(IServiceCollection services)
	{
		services.AddTransient<GetDrugsQueryHandler>();
	}

	private static void RegisterFilterYearHandlers(IServiceCollection services)
	{
		services.AddTransient<GetFilterYearQueryHandler>();
		services.AddTransient<EditFilterYearCommandHandler>();
	}

	private static void RegisterPwoHandlers(IServiceCollection services)
	{
		services.AddTransient<GetPwoDetailQueryHandler>();
		services.AddTransient<PwoCloseCommandHandler>();
		services.AddTransient<PwoConfirmCommandHandler>();
	}

	private static void RegisterUserHandlers(IServiceCollection services)
	{
		services.AddTransient<GetUserQueryHandler>();
		services.AddTransient<GetUsersQueryHandler>();
		services.AddTransient<EditUserCommandHandler>();
	}

	private static void RegisterCustomerHandlers(IServiceCollection services)
	{
		services.AddTransient<GetCustomerQueryHandler>();
		services.AddTransient<GetCustomersQueryHandler>();
		services.AddTransient<EditCustomerCommandHandler>();
	}

	private static void RegisterDietRequestHandlers(IServiceCollection services)
	{
		services.AddTransient<GetDietRequestQueryHandler>();
		services.AddTransient<CreateDietRequestCommandHandler>();
		services.AddTransient<UpdateDietRequestCommandHandler>();
		services.AddTransient<GetDietRequestsQueryHandler>();
		services.AddTransient<DeleteDietRequestCommandHandler>();
		services.AddTransient<CloneDietRequestCommandHandler>();
	}

	private static void RegisterFeedStuffHandlers(IServiceCollection services)
	{
		services.AddTransient<GetFeedStuffsQueryHandler>();
		services.AddTransient<GetFeedStuffQueryHandler>();
		services.AddTransient<GetFeedStuffPlanningQueryHandler>();
		services.AddTransient<CreateFeedStuffCommandHandler>();
		services.AddTransient<UpdateFeedStuffCommandHandler>();
	}

	private static void RegisterFeedLabelHandlers(IServiceCollection services)
	{
		services.AddTransient<GetFeedLabelQueryHandler>();
		services.AddTransient<GetFeedLabelsQueryHandler>();
		services.AddTransient<PrintFeedLabelHandler>();
		services.AddTransient<PrintFeedLabelAdditiveHandler>();
	}
}