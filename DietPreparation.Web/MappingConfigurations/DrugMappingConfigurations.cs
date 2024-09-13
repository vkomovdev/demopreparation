using DietPreparation.Application.Commands.Requests;
using DietPreparation.Application.Queries.Requests.Drugs;
using DietPreparation.Application.Queries.Responses.Drugs;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Web.Models.Drugs;
using DietPreparation.Web.Models.TableOptions;
using Mapster;

namespace DietPreparation.Web.MappingConfigurations;

internal class DrugMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<DrugDto, DrugViewModel>()
			.Map(dest => dest.UnitOfMeasure, src => src.ConcentrationUnitOfMeasure.GetDisplayName())
			.Map(dest => dest.Id, src => src.Id)
			.Map(dest => dest.Name, src => src.Name)
			.Map(dest => dest.ActiveIngredientConcentration, src => src.ActiveIngredientConcentration.ToString("N3"))
			.Map(dest => dest.CreateDate, src => src.CreateDate.ToString(FormatStrings.NetDateFormat))
			.Map(dest => dest.CreateName, src => src.CreateName)
			.Map(dest => dest.IsActive, src => src.IsActive)
			.Map(dest => dest.IsLocked, src => src.IsLocked);

		config.NewConfig<GetDrugQueryResponse, DrugUpdateViewModel>()
			.Map(dest => dest.UnitOfMeasure, src => src.Drug.ConcentrationUnitOfMeasure.GetNumberAsString())
			.Map(dest => dest.Id, src => src.Drug.Id)
			.Map(dest => dest.Name, src => src.Drug.Name)
			.Map(dest => dest.CreatedAt, src => src.Drug.CreateDate.ToString(FormatStrings.NetDateFormat))
			.Map(dest => dest.UserId, src => src.Drug.CreateName)
			.Map(dest => dest.ActiveIngredientConcentration, src => src.Drug.ActiveIngredientConcentration);

		config.NewConfig<TableOptionsViewModel, GetFilteredDrugsQueryRequest>()
			.Map(dest => dest.OrderBy, src => MapOrderBy(src.OrderBy))
			.Map(dest => dest.Pagination, src => src.Pagination);

		config.NewConfig<DrugUpdateViewModel, CreateUpdateDrugRequest>()
			.Map(dest => dest.Drug, src => src);
	}

	private static OrderByDto? MapOrderBy(OrderByViewModel? src)
	{
		return !string.IsNullOrEmpty(src?.Column) ? src.Adapt<OrderByDto>() : null;
	}
}