using DietPreparation.Common.Consts;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;
public class PremixMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.ForType<PwoPremixDao, PwoPremixDto>()
			.Map(dest => dest.PwoId, src => src.PWO_ID)
			.Map(dest => dest.RequestId, src => src.REQUEST_ID)
			.Map(dest => dest.Amount, src => @Math.Round(src.AMOUNT, DefaultNumbers.DecimalDigitsCount))
			.Map(dest => dest.AmountUom, src => src.AMOUNT_UOM)
			.Map(dest => dest.LotYear, src => src.LOT_YEAR)
			.Map(dest => dest.LotId, src => src.LOT_ID)
			.Map(dest => dest.DietName, src => src.DIET_NAME);

		config.NewConfig<PremixDao, PremixDto>()
			.Map(dest => dest.Id, src => src.PREMIX_ID);
	}
}
