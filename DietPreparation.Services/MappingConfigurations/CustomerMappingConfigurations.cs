using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class CustomerMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CustomerDao, CustomerDto>()
			.Map(dest => dest.Id, src => src.CUSTOMER_ID)
			.Map(dest => dest.FirstName, src => src.FIRST_NAME)
			.Map(dest => dest.LastName, src => src.LAST_NAME)
			.Map(dest => dest.Type, src => src.CUSTOMER_TYPE.GetEnumFromDatabaseValue<CustomerType>())
			.Map(dest => dest.MiddleName, src => src.MIDDLE_INITIAL)
			.Map(dest => dest.Email, src => src.EMAIL)
			.Map(dest => dest.Building, src => src.BUILDING)
			.Map(dest => dest.BusinessUnit, src => src.UNIT.HasValue ? src.UNIT.Value.ToString() : "")
			.Map(dest => dest.Lock, src => src.LOCK)
			.Map(dest => dest.TotalItems, src => src.TotalItems);

		config.NewConfig<CustomerDto, CreateUpdateCustomerDao>()
			.Map(dest => dest.CUSTOMER_ID, src => src.Id)
			.Map(dest => dest.FIRST_NAME, src => src.FirstName)
			.Map(dest => dest.LAST_NAME, src => src.LastName)
			.Map(dest => dest.MIDDLE_INITIAL, src => src.MiddleName)
			.Map(dest => dest.EMAIL, src => src.Email)
			.Map(dest => dest.BUILDING, src => src.Building)
			.Map(dest => dest.UNIT, src => string.IsNullOrEmpty(src.BusinessUnit) ? null : src.BusinessUnit)
			.Map(dest => dest.CUSTOMER_TYPE, src => src.Type.GetDatabaseValue());
	}
}
