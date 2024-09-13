using DietPreparation.Application.Commands.Responses.DietRequests;
using DietPreparation.Application.Queries.Responses.DietRequests;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations.DietRequests;

internal class DietRequestMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<MedicatedPremixDto, DietRequestPremixDto>()
			.Map(dest => dest.Premix, src => src);

		config.NewConfig<IEnumerable<DietRequestDto>, GetDietRequestSearchQueryResponse>()
			.Map(dest => dest.DietRequests, src => src)
			.Map(dest => dest.TotalItems, src => (src != null && src.Any()) ? src.First().TotalItems : 0);

		config.NewConfig<IEnumerable<DietRequestDto>, GetDietRequestCreateQueryResponse>()
			.Map(dest => dest.DietRequests, src => src)
			.Map(dest => dest.TotalItems, src => (src != null && src.Any()) ? src.First().TotalItems : 0);

		config.NewConfig<IEnumerable<DietRequestDto>, GetDietRequestCloseQueryResponse>()
			.Map(dest => dest.DietRequests, src => src)
			.Map(dest => dest.TotalItems, src => (src != null && src.Any()) ? src.First().TotalItems : 0);

		config.NewConfig<PaginationDto, GetDietRequestSearchQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<PaginationDto, GetDietRequestsQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<PaginationDto, GetDietRequestCreateQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<PaginationDto, GetDietRequestCloseQueryResponse>()
			.Map(dest => dest.Page, src => src.Page)
			.Map(dest => dest.PageSize, src => src.PageSize);

		config.NewConfig<IEnumerable<DietRequestTinyDto>, GetNotUsedMedicatedPremixesQueryResponse>()
			.Map(dest => dest.MedicatedPremixes, src => src);

		config.NewConfig<IEnumerable<DietRequestTinyDto>, GetUsedMedicatedPremixesQueryResponse>()
			.Map(dest => dest.MedicatedPremixes, src => src);

		config.NewConfig<IEnumerable<DietRequestTinyDto>, GetNotClonedDietRequestsQueryResponse>()
			.Map(dest => dest.DietRequests, src => src);

		config.NewConfig<IEnumerable<DietRequestTinyDto>, GetClonedDietRequestsQueryResponse>()
			.Map(dest => dest.DietRequests, src => src);

		config.NewConfig<DietPreparationException, ActivateDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, ActivatePremixResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, CloneDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, CreateDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, DeactivatePremixResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, DeleteDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, DisableDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, EnableDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, UpdateDietRequestResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetClonedDietRequestsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetDietRequestQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetDietRequestsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetNotClonedDietRequestsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetNotUsedMedicatedPremixesQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetUsedMedicatedPremixesQueryResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}