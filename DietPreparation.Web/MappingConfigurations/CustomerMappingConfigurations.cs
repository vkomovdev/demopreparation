using DietPreparation.Application.Commands.Requests.Customers;
using DietPreparation.Application.Queries.Requests.Customers;
using DietPreparation.Application.Queries.Responses.Customers;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.Customers;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using System.Web;

namespace DietPreparation.Web.MappingConfigurations
{
	internal class CustomerMappingConfigurations : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			RegisterQueries(config);
			RegisterCommands(config);
		}

		private void RegisterQueries(TypeAdapterConfig config)
		{
			config.NewConfig<CustomerDto, CustomerListItemViewModel>()
				.Map(dest => dest.EncodedCustomerId, src => HttpUtility.UrlEncode(src.Id.ToString()))
				.Map(dest => dest.FirstName, src => src.FirstName)
				.Map(dest => dest.MiddleName, src => src.MiddleName)
				.Map(dest => dest.LastName, src => src.LastName)
				.Map(dest => dest.Email, src => src.Email)
				.Map(dest => dest.CustomerType, src => src.Type.GetDisplayName())
				.Map(dest => dest.Building, src => src.Building)
				.Map(dest => dest.BusinessUnit, src => src.BusinessUnit);

			config.NewConfig<GetCustomerQueryResponse, CustomerViewModel>()
				.Map(dest => dest, src => src.Customer);

			config.NewConfig<TableOptionsViewModel, GetCustomersQueryRequest>()
				.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
				.Map(dest => dest.Pagination, src => src.Pagination);
		}

		private void RegisterCommands(TypeAdapterConfig config)
		{
			config.NewConfig<CustomerViewModel, CreateCustomerRequest>();
			config.NewConfig<CustomerViewModel, EditCustomerRequest>();
		}

		private static OrderByDto? MapOrderBy(OrderByViewModel? src)
		{
			return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
		}
	}
}