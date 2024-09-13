using DietPreparation.Application.Queries.Requests.DietRequests;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Models.DTO.TableOptions;
using DietPreparation.Web.Models.DietRequests;
using DietPreparation.Web.Models.TableOptions;
using Mapster;
using Newtonsoft.Json;

namespace DietPreparation.Web.MappingConfigurations;

public class ReadDietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<GetDietRequestsQueryResponse, DietRequestSearchViewModel>()
			.Map(dest => dest.DietRequests, src => src.DietRequests)
			.Map(dest => dest.TotalItems, src => src.TotalItems)
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<DietRequestSearchDto, DietRequestSearchItem>()
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Lot, src => src.Lot)
			.Map(dest => dest.Requestor, src => src.Requestor)
			.Map(dest => dest.Receiver, src => src.Receiver)
			.Map(dest => dest.DateRequest, src => src.DateRequest.ToString(FormatStrings.NetDateFormat).ToUpper())
			.Map(dest => dest.DateNeeded, src => src.DateNeeded.ToString(FormatStrings.NetDateFormat).ToUpper())
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.RequestAmount, src => src.RequestAmount)
			.Map(dest => dest.UnitOfMeasure, src => src.UnitOfMeasure != null ? src.UnitOfMeasure.GetDisplayName() : string.Empty)
			.Map(dest => dest.IsLocked, src => src.IsLocked)
			.Map(dest => dest.IsDeleted, src => src.IsDeleted)
			.Map(dest => dest.UsedAsTemplate, src => src.UsedAsTemplate);

		config.NewConfig<TableOptionsViewModel, GetDietRequestsQueryRequest>()
			.Map(dest => dest.Pagination, src => src.Pagination)
			.Map(dest => dest.OrderBy, src => src.OrderBy)
			.Map(dest => dest.FilterBy, src => string.IsNullOrWhiteSpace(src.Filter) ? null :
				JsonConvert.DeserializeObject<DietRequestFilterDto>(src.Filter));
	}
}