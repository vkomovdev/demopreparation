using DietPreparation.Common.Enums;
using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.AuditLogs;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using DietPreparation.Utilities.Logger;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;

internal class DietRequestUpdater : IDietRequestUpdater
{
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IDietRequestBasalDietRepository _dietRequestBasalDietRepository;
	private readonly IDietRequestExternalFeedRepository _dietRequestExternalFeedRepository;
	private readonly IDrugService _drugService;
	private readonly IPremixService _premixService;
	private readonly ISampleService _sampleService;
	private readonly IAuditCreator _auditCreator;
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDietPreparationLogger _logger;

	public DietRequestUpdater(
		IDietRequestRepository dietRequestRepository,
		IDietRequestBasalDietRepository dietRequestBasalDietRepository,
		IDietRequestExternalFeedRepository dietRequestExternalFeedRepository,
		IDrugService drugService,
		IPremixService premixService,
		ISampleService sampleService,
		IAuditCreator auditCreator,
		IUnitOfWork unitOfWork,
		IDietPreparationLogger logger,
		IMapper mapper)
	{
		_dietRequestRepository = dietRequestRepository;
		_dietRequestBasalDietRepository = dietRequestBasalDietRepository;
		_dietRequestExternalFeedRepository = dietRequestExternalFeedRepository;

		_drugService = drugService;
		_premixService = premixService;
		_sampleService = sampleService;
		_auditCreator = auditCreator;
		_unitOfWork = unitOfWork;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<bool> ActivateAsync(int requestId)
		=> await _dietRequestRepository.ActivatePremixAsync(requestId);

	public async Task<bool> DeactivateAsync(int requestId)
		=> await _dietRequestRepository.DeactivatePremixAsync(requestId);

	public async Task<bool> DisableAsync(int requestId)
		=> await _dietRequestRepository.DisableAsync(requestId);

	public async Task<bool> EnableAsync(int requestId)
		=> await _dietRequestRepository.EnableAsync(requestId);

	public async Task<DietRequestDto> UpdateAsync(DietRequestDto dietRequestDto, AuditCreateDto auditCreate)
	{
		try
		{
			await _unitOfWork.BeginAsync();

			var result = await UpdateDietRequest(dietRequestDto);

			var auditDto = _mapper.Map<AuditDto>(auditCreate);
			_mapper.Map(result, auditDto);
			await _auditCreator.CreateAsync(auditDto);

			await _unitOfWork.CommitAsync();
			return result;
		}
		catch (Exception exception)
		{
			_logger.Error("An exception occured during DietRequest Update. ", exception);
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}

	public async Task<DietRequestDto> UpdateAsync(DietRequestDto dietRequestDto)
	{
		try
		{
			await _unitOfWork.BeginAsync();

			var result = await UpdateDietRequest(dietRequestDto);

			await _unitOfWork.CommitAsync();
			return result;
		}
		catch (Exception exception)
		{
			_logger.Error("An exception occured during DietRequest Update. ", exception);
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}
	private async Task<DietRequestDto> UpdateDietRequest(DietRequestDto dietRequestDto)
	{
		var upsertResult = await _dietRequestRepository.UpsertAsync(_mapper.Map<DietRequestDao>(dietRequestDto));
		if (dietRequestDto.IsDeleted)
		{
			await _dietRequestRepository.DeleteAsync(dietRequestDto.Id);
		}

		_mapper.Map(upsertResult, dietRequestDto);

		await UpdateDrugs(dietRequestDto);
		await UpdatePremixes(dietRequestDto);
		await UpdateSamples(dietRequestDto);

		await _dietRequestBasalDietRepository.DeleteByRequestIdAsync(dietRequestDto.Id);
		await _dietRequestExternalFeedRepository.DeleteByRequestIdAsync(dietRequestDto.Id);

		switch (dietRequestDto.FeedType)
		{
			case FeedType.Basal:
				var dietRequestBasalDiet = _mapper.Map<DietRequestBasalDietDto>(dietRequestDto);
				await _dietRequestBasalDietRepository.InsertAsync(_mapper.Map<DietRequestBasalDietDao>(dietRequestBasalDiet));
				break;
			case FeedType.External:
				var dietRequestExternalFeed = _mapper.Map<DietRequestExternalFeedDto>(dietRequestDto);
				await _dietRequestExternalFeedRepository.InsertAsync(_mapper.Map<DietRequestExternalFeedDao>(dietRequestExternalFeed));
				break;
		}
		return dietRequestDto;
	}

	private async Task UpdateDrugs(DietRequestDto dietRequest)
	{
		await _drugService.DeleteByRequestIdAsync(dietRequest.Id);

		if (dietRequest.Drugs is not null)
		{
			foreach (var drugDto in dietRequest.Drugs)
			{
				drugDto.DietRequestId = dietRequest.Id;
				await _drugService.CreateAsync(drugDto);
			};
		}
	}

	private async Task UpdatePremixes(DietRequestDto dietRequest)
	{
		await _premixService.DeleteByRequestIdAsync(dietRequest.Id);

		if (dietRequest.Premixes is not null)
		{
			foreach (var premixDto in dietRequest.Premixes)
			{
				premixDto.DietRequestId = dietRequest.Id;
				await _premixService.CreateAsync(premixDto);
			};
		}
	}

	private async Task UpdateSamples(DietRequestDto dietRequest)
	{
		await _sampleService.DeleteByRequestIdAsync(dietRequest.Id);

		if (dietRequest.Samples is not null)
		{
			foreach (var sampleDto in dietRequest.Samples)
			{
				sampleDto.DietRequestId = dietRequest.Id;
				await _sampleService.CreateAsync(sampleDto);
			};
		}
	}
}