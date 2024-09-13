using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Spaces.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.AuditLogs;

internal class AuditReader : IAuditReader
{
	private readonly IAuditRepository _auditRepository;
	private readonly ICustomerRepository _customerRepository;
	private readonly IMapper _mapper;

	public AuditReader(
		IAuditRepository auditRepository,
		ICustomerRepository customerRepository,
		IMapper mapper)
	{
		_auditRepository = auditRepository;
		_customerRepository = customerRepository;
		_mapper = mapper;
	}

	public async Task<AuditDto> ReadAsync(int id)
	{
		var entity = _mapper.Map<AuditDto>(await _auditRepository.ReadAsync(id));

		var drugDaos = await _auditRepository.ReadDrugsAsync(id);
		var drugs = _mapper.Map<IEnumerable<AuditDrugDto>>(drugDaos);
		_mapper.Map(drugs, entity);

		var premixDaos = await _auditRepository.ReadPremixesAsync(id);
		var premixes = _mapper.Map<IEnumerable<AuditPremixDto>>(premixDaos);
		_mapper.Map(premixes, entity);

		var sampleDaos = await _auditRepository.ReadSamplesAsync(id);
		var samples = _mapper.Map<IEnumerable<AuditSampleDto>>(sampleDaos);
		_mapper.Map(samples, entity);

		if (entity.RequestorID.HasValue)
		{
			var requestor = await _customerRepository.ReadAsync(entity.RequestorID.Value.ToString());
			entity.RequesterName = requestor == null ? string.Empty : _mapper.Map<CustomerDto>(requestor).GetFullName();
		}

		if (entity.DeliverID.HasValue)
		{
			var receiver = await _customerRepository.ReadAsync(entity.DeliverID.Value.ToString());
			entity.ReceiverName = receiver == null ? string.Empty : _mapper.Map<CustomerDto>(receiver).GetFullName();
		}

		return entity;
	}
}
