using DietPreparation.Common.Consts;
using DietPreparation.Models.DAO.DietRequests;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestMedicatedPremixMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<MedicatedPremixDao, MedicatedPremixDto>()
			.Map(dest => dest.Id, src => src.REQUEST_ID)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.Name, src => src.DIET_NAME)
			.Map(dest => dest.IsDeleted, src => src.ISDELETED.Trim() == DefaultStrings.Yes)
			.Map(dest => dest.PremixUsed, src => src.PremixUsed);
	}
}
