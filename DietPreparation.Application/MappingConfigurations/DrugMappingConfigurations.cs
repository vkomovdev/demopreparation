using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Commands.Responses;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;
internal class DrugMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<DrugDto>, GetDrugsQueryResponse>()
			.Map(dest => dest.Drugs, src => src);

		config.NewConfig<DrugDto, DietRequestDrugDto>()
			.Map(dest => dest.Drug, src => src);

		config.NewConfig<DrugDto, GetDrugQueryResponse>()
			.Map(dest => dest.Drug, src => src);

		config.NewConfig<CreateUpdateDrugRequest, DrugUpdateDto>()
			.Map(dest => dest, src => src.Drug);

		config.NewConfig<IEnumerable<DrugsItemDto>, GetFilteredDrugsQueryResponse>()
			.Map(dest => dest.Drugs, src => src)
			.Map(dest => dest.TotalItems, src => src.First().TotalItems);

		config.NewConfig<DietPreparationException, GetDrugQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetDrugsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetFilteredDrugsQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, CreateUpdateDrugResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}