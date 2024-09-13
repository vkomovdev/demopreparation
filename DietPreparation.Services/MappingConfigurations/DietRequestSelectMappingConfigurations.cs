using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO.DietRequests;
using DietPreparation.Models.DTO.DietRequests;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestSelectMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestSelectDao, DietRequestSelectDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.Lot, src => $"{src.LOT_YEAR} {src.LOT_ID}")
			.Map(dest => dest.Requestor, src => $"{src.Fname}, {src.Lname}")
			.Map(dest => dest.DateRequest, src => src.DATE_REQUEST)
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.RequestAmount, src => src.REQUEST_AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => src.REQUEST_UOM.GetEnum<UnitOfMeasure>());
	}
}
