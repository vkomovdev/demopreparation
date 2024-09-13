using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Commands.Responses.Customers;
using DietPreparation.Application.Commands.Responses.Users;
using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Application.Queries.Responses.Users;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class CustomerMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		RegisterQueries(config);
		RegisterCommands(config);
	}

	private void RegisterQueries(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<CustomerDto>, GetCustomersQueryResponse>()
			.Map(dest => dest.Customers, src => src)
			.Map(dest => dest.TotalItems, src => src.First().TotalItems);

		config.NewConfig<CustomerDto, GetCustomerQueryResponse>()
			.Map(dest => dest.Customer, src => src);

		config.NewConfig<DietPreparationException, GetCustomersQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<PaginationDto, GetCustomersQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);
	}

	private void RegisterCommands(TypeAdapterConfig config)
	{
		config.NewConfig<CreateCustomerRequest, CustomerDto>()
			.Map(dest => dest.Type, src => src.CustomerType);

		config.NewConfig<EditCustomerRequest, CustomerDto>()
			.Map(dest => dest.Type, src => src.CustomerType);

		config.NewConfig<CustomerDto, CreateCustomerResponse>();
		config.NewConfig<CustomerDto, EditCustomerResponse>();

		config.NewConfig<DietPreparationException, CreateCustomerResponse>()
				.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, EditCustomerResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetCustomerQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetCustomersQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}

}
