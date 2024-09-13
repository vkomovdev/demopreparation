using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO.DietRequests;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestSearchMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDao, DietRequestSearchDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.Lot, src => src.LOT)
			.Map(dest => dest.Requestor, src => src.REQUESTOR)
			.Map(dest => dest.Receiver, src => src.RECEIVER)
			.Map(dest => dest.DateRequest, src => src.DATE_REQUEST)
			.Map(dest => dest.DateNeeded, src => src.DATE_NEEDED)
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.RequestAmount, src => src.REQUEST_AMOUNT)
			.Map(dest => dest.UnitOfMeasure, src => string.IsNullOrWhiteSpace(src.REQUEST_UOM) ? (UnitOfMeasure?)null :
				src.REQUEST_UOM.Trim().GetEnum<UnitOfMeasure>())
			.Map(dest => dest.IsLocked, src => src.LOCK)
			.Map(dest => dest.IsDeleted, src => src.ISDELETED.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.UsedAsTemplate, src => src.USEDASTEMPLATE.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.TotalItems, src => src.TotalItems);
	}
}