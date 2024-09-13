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

internal class DietRequestCreator : IDietRequestCreator
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

	public DietRequestCreator(
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

	public async Task<DietRequestDto> CreateAsync(DietRequestDto dietRequestDto)
	{
		try
		{
			await _unitOfWork.BeginAsync();

			var result = await CreateDietRequest(dietRequestDto);

			await _unitOfWork.CommitAsync();
			return result;
		}
		catch (Exception)
		{
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}

	public async Task<DietRequestDto> CreateAsync(DietRequestDto dietRequestDto, AuditCreateDto auditCreate)
	{
		try
		{
			await _unitOfWork.BeginAsync();

			var createdDietRequest = await CreateDietRequest(dietRequestDto);

			var auditDto = _mapper.Map<AuditDto>(auditCreate);
			_mapper.Map(createdDietRequest, auditDto);
			await _auditCreator.CreateAsync(auditDto);

			await _unitOfWork.CommitAsync();
			return createdDietRequest;
		}
		catch (Exception exception)
		{
			_logger.Error("An exception occured during DietRequest Create. ", exception);
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}

	private async Task<DietRequestDto> CreateDietRequest(DietRequestDto dietRequestDto)
	{
		var upsertResult = await _dietRequestRepository.UpsertAsync(_mapper.Map<DietRequestDao>(dietRequestDto));
		_mapper.Map(upsertResult, dietRequestDto);

		await CreateDrugs(dietRequestDto);
		await CreatePremixes(dietRequestDto);
		await CreateSamples(dietRequestDto);

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

	private async Task CreateDrugs(DietRequestDto dietRequest)
	{
		if (dietRequest.Drugs is not null)
		{
			foreach (var drugDto in dietRequest.Drugs)
			{
				drugDto.DietRequestId = dietRequest.Id;
				await _drugService.CreateAsync(drugDto);
			}
		}
	}

	private async Task CreatePremixes(DietRequestDto dietRequest)
	{
		if (dietRequest.Premixes is not null)
		{
			foreach (var premixDto in dietRequest.Premixes)
			{
				premixDto.DietRequestId = dietRequest.Id;
				await _premixService.CreateAsync(premixDto);
			}
		}
	}

	private async Task CreateSamples(DietRequestDto dietRequest)
	{
		if (dietRequest.Samples is not null)
		{
			foreach (var sampleDto in dietRequest.Samples)
			{
				sampleDto.DietRequestId = dietRequest.Id;
				await _sampleService.CreateAsync(sampleDto);
			}
		}
	}
}