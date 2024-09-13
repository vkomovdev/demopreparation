using DietPreparation.Common.Consts;
using DietPreparation.Common.Enums;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.DietRequests;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Services.Customers;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using DietPreparation.Services.Locations.Interfaces;
using DietPreparation.Services.Premixes.Interfaces;
using DietPreparation.Services.Samples.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;
internal class DietRequestReader : IDietRequestReader
{
	private readonly IDrugService _drugService;
	private readonly IPremixService _premixService;
	private readonly ISampleService _sampleService;
	private readonly IBasalDietReader _basalDietReader;
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IPremixRepository _premixRepository;
	private readonly ICustomerReader _customerReader;
	private readonly ILocationReader _locationReader;
	private readonly IMapper _mapper;

	public DietRequestReader(
		IDrugService drugService,
		IPremixService premixService,
		ISampleService sampleService,
		IBasalDietReader basalDietReader,
		IDietRequestRepository dietRequestRepository,
		IPremixRepository premixRepository,
		ICustomerReader customerReader,
		ILocationReader locationReader,
		IMapper mapper)
	{
		_drugService = drugService;
		_premixService = premixService;
		_sampleService = sampleService;
		_basalDietReader = basalDietReader;
		_dietRequestRepository = dietRequestRepository;
		_premixRepository = premixRepository;
		_customerReader = customerReader;
		_locationReader = locationReader;
		_mapper = mapper;
	}

	public async Task<DietRequestDto> ReadFullAsync(int id)
	{
		var dietRequest = _mapper.Map<DietRequestDto>(await _dietRequestRepository.ReadAsync(id));

		if (dietRequest.RequestorId.HasValue)
		{
			dietRequest.Requestor = await _customerReader.ReadAsync(dietRequest.RequestorId.Value);
		}

		if (dietRequest.RecieverId.HasValue)
		{
			dietRequest.Receiver = await _customerReader.ReadAsync(dietRequest.RecieverId.Value);
		}

		if (dietRequest.LocationId.HasValue)
		{
			dietRequest.Location = await _locationReader.ReadAsync(dietRequest.LocationId.Value);
		}

		if (dietRequest.FeedType is FeedType.Basal)
		{
			_mapper.Map(await _basalDietReader.ReadByRequestIdAsync(dietRequest.Id), dietRequest);
		}

		_mapper.Map(await _drugService.ReadByRequestIdAsync(id), dietRequest);
		_mapper.Map(await _premixService.ReadByRequestIdAsync(id), dietRequest);
		_mapper.Map(await _sampleService.ReadByRequestIdAsync(id), dietRequest);

		return dietRequest;
	}

	public async Task<DietRequestDto> ReadAsync(int id) => _mapper.Map<DietRequestDto>(await _dietRequestRepository.ReadAsync(id));

	public async Task<IEnumerable<DietRequestSelectDto>> ReadAllAsync() => _mapper.Map<IEnumerable<DietRequestSelectDto>>(await _dietRequestRepository.ReadAllAsync());

	public async ValueTask<bool> IsPremixLockedAsync(int premixId)
	{
		var isPremixLock = await _premixRepository.IsPremixLockedAsync(premixId);
		return isPremixLock;
	}

	public async ValueTask<decimal> ReadMaxCapacityAsync(UnitOfMeasure requestUom)
	{
		var maxCapacity = await _dietRequestRepository.ReadAppSetupKeyAsync();

		maxCapacity = requestUom switch
		{
			UnitOfMeasure.Pound => maxCapacity * ConversionRates.Pounds,
			UnitOfMeasure.Gram => maxCapacity * ConversionRates.Grams,
			_ => maxCapacity
		};

		return maxCapacity;
	}

	public async ValueTask<string> PreTestRequestAsync(int requestId) => await _dietRequestRepository.PreTestRequestAsync(requestId);
}
