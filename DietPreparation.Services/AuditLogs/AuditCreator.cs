using DietPreparation.Models.DAO.AuditLogs;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.AuditLogs;

internal class AuditCreator : IAuditCreator
{
	private readonly IAuditRepository _auditRepository;
	private readonly IMapper _mapper;

	public AuditCreator(IAuditRepository auditRepository, IMapper mapper)
	{
		_auditRepository = auditRepository;
		_mapper = mapper;
	}

	public async Task<AuditDto> CreateAsync(AuditDto auditDto)
	{
		auditDto.Id = await _auditRepository.CreateDietRequestAuditAsync(_mapper.Map<AuditDao>(auditDto));

		await CreateDrugsAsync(auditDto);
		await CreatePremixesAsync(auditDto);
		await CreateSamplesAsync(auditDto);

		return auditDto;
	}

	private async Task CreateDrugsAsync(AuditDto auditDto)
	{
		if (auditDto.Drugs == null)
			return;

		foreach (var drug in auditDto.Drugs)
		{
			drug.AuditLogNumber = auditDto.Id;
			await _auditRepository.CreateDrugAsync(_mapper.Map<AuditDrugDao>(drug));
		}
	}

	private async Task CreatePremixesAsync(AuditDto auditDto)
	{
		if (auditDto.Premixes == null)
			return;

		foreach (var premix in auditDto.Premixes)
		{
			premix.AuditLogNumber = auditDto.Id;
			await _auditRepository.CreatePremixAsync(_mapper.Map<AuditPremixDao>(premix));
		}
	}

	private async Task CreateSamplesAsync(AuditDto auditDto)
	{
		if (auditDto.Samples == null)
			return;

		foreach (var sample in auditDto.Samples)
		{
			sample.AuditLogNumber = auditDto.Id;
			await _auditRepository.CreateSampleAsync(_mapper.Map<AuditSampleDao>(sample));
		}
	}
}
