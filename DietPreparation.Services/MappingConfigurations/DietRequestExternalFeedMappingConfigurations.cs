using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using Mapster;

namespace DietPreparation.Services.MappingConfigurations;

internal class DietRequestExternalFeedMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DietRequestDto, DietRequestExternalFeedDto>()
			.Map(dest => dest.RequestId, src => src.Id)
			.Map(dest => dest.SupplierName, src => src.FeedSupplierName)
			.Map(dest => dest.LotNumber, src => src.FeedSupplierLotNumber);

		config.NewConfig<DietRequestExternalFeedDto, DietRequestExternalFeedDao>()
			.TwoWays()
			.Map(dest => dest.RECORD_ID, src => src.RecordId)
			.Map(dest => dest.REQUEST_ID, src => src.RequestId)
			.Map(dest => dest.SUPPLIER_NAME, src => src.SupplierName)
			.Map(dest => dest.LOT_NUMBER, src => src.LotNumber);
	}
}