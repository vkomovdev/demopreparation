using DietPreparation.Common.Enums;
using DietPreparation.Models.DTO.FeedLabels;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.FeedLabels.Interfaces;
using DietPreparation.Services.PWOs.Interfaces;
using DietPreparation.Utilities.ExceptionHandler;
using Mapster;
using MapsterMapper;

namespace DietPreparation.Services.FeedLabels;

internal class FeedLabelReader : IFeedLabelReader
{
	private readonly IPwoReader _pwoReader;
	private readonly IBasalDietReader _basalDietReader;
	private readonly IMapper _mapper;

	public FeedLabelReader(IPwoReader pwoReader, IBasalDietReader basalDietReader, IMapper mapper)
	{
		_pwoReader = pwoReader;
		_basalDietReader = basalDietReader;
		_mapper = mapper;
	}

	public async Task<FeedLabelDto> ReadAsync(int requestId, int sequence)
	{
		var header = await _pwoReader.ReadHeaderAsync(requestId, sequence);

		if (header.PwoDto is null || header.DietRequest is null)
		{
			throw new DietPreparationException(CommonErrorCode.EntityNotFound);
		}

		var dto = new FeedLabelDto { Id = requestId };
		_mapper.Map(header.DietRequest, dto);
		_mapper.Map(header.PwoDto, dto);

		var pwoDrugs = await _pwoReader.ReadDrugsAsync(header.PwoDto.PwoId);
		var premixDrugs = await _pwoReader.ReadPremixDrugsAsync(header.PwoDto.PwoId);
		dto.Drugs = new List<FeedLabelDto.DrugRow>();
		dto.Drugs = dto.Drugs.Concat(pwoDrugs.Adapt<List<FeedLabelDto.DrugRow>>());
		dto.Drugs = dto.Drugs.Concat(premixDrugs.Adapt<List<FeedLabelDto.DrugRow>>());

		dto.SummaryOfDrugConcentration = dto.Drugs
			.GroupBy(drug => drug.ConcentrationUnitOfMeasure)
			.Select(group => new FeedLabelDto.ConcentrationSummary
			{
				ConcentrationUnitOfMeasure = group.Key,
				Concentration = group.Sum(drug => drug.Concentration)
			});

		dto.BasalId = header.DietRequest.FeedType switch
		{
			FeedType.Basal => (await _basalDietReader.ReadByRequestIdAsync(requestId)).BasalDiet?.Code,
			FeedType.External => header.DietRequest.FeedSupplierLotNumber,
			_ => dto.BasalId
		};

		return dto;
	}
}