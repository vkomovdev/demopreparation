using DietPreparation.Application.Commands.Requests.PWOs;
using DietPreparation.Application.Commands.Responses.PWOs;
using DietPreparation.Application.Queries.Responses;
using DietPreparation.Application.Queries.Responses.PWOs;
using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Common.Extensions;
using DietPreparation.Models.DTO;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;

namespace DietPreparation.Application.MappingConfigurations;

internal class PwoMappingConfigurations : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<PwoHeaderDto, GetPwoDetailQueryResponse>()
			.Map(dest => dest.Header, src => src);

		config.NewConfig<IEnumerable<PwoIngredientDto>, GetPwoDetailQueryResponse>()
			.Map(dest => dest.Ingredients, src => src);

		config.NewConfig<IEnumerable<PwoDrugDto>, GetPwoDetailQueryResponse>()
			.Map(dest => dest.Drugs, src => src);

		config.NewConfig<IEnumerable<PwoPremixDto>, GetPwoDetailQueryResponse>()
			.Map(dest => dest.Premixes, src => src);

		config.NewConfig<IEnumerable<PwoPremixDrugDto>, GetPwoDetailQueryResponse>()
			.Map(dest => dest.PremixDrugs, src => src);

		config.NewConfig<int, GetPwoDetailQueryResponse>()
			.Map(dest => dest.RequestId, src => src);

		config.NewConfig<PwoCloseDto, PwoCloseResponse>()
			.Map(dest => dest.PwoId, src => src.PwoId);

		config.NewConfig<PwoCloseRequest, PwoCloseDto>();

		config.NewConfig<DietRequestDto, GetBatchQueryResponse>()
			.Map(dest => dest.RequestId, src => src.Id)
			.Map(dest => dest.Lot, src => $"{src.LotYear} {src.LotId}")
			.Map(dest => dest.CustomerName, src => $"{src.Requestor.FirstName} {src.Requestor.LastName}")
			.Map(dest => dest.DietName, src => src.Name)
			.Map(dest => dest.RequestUom, src => src.UnitOfMeasure);

		config.NewConfig<IEnumerable<PwoSelectAllDto>, GetBatchesQueryResponse>()
			.Ignore(dest => dest.RequestId)
			.Map(dest => dest.Batches, src => src.Select(x => new BatchItem()
			{
				Sequence = x.Sequence,
				BatchUom = x.BatchUom.GetEnum<UnitOfMeasure>(),
				BatchWeight = @Math.Round(x.BatchWeight, DefaultNumbers.DecimalDigitsCount)
			}))
			.Map(dest => dest.Lot, src => $"{src.First().LotYear} {src.First().LotId}")
			.Map(dest => dest.CustomerName, src => $"{src.First().FirstName} {src.First().LastName}")
			.Map(dest => dest.DietName, src => src.First().DietName);

		config.NewConfig<DietPreparationException, GetDietRequestCloseQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetDietRequestCreateQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetDietRequestSearchQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, GetPwoDetailQueryResponse>()
			.Map(dest => dest.Exception, src => src);

		config.NewConfig<DietPreparationException, PwoCloseResponse>()
			.Map(dest => dest.Exception, src => src);
	}
}
