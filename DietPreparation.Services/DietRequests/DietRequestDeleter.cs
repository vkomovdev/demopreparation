using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DTO.AuditLogs;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.AuditLogs;
using DietPreparation.Services.DietRequests.Interfaces;
using DietPreparation.Utilities.Logger;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;

internal class DietRequestDeleter : IDietRequestDeleter
{
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IDietRequestReader _dietRequestReader;
	private readonly IAuditCreator _auditCreator;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDietPreparationLogger _logger;
	private readonly IMapper _mapper;

	public DietRequestDeleter(
		IDietRequestRepository dietRequestRepository,
		IDietRequestReader dietRequestReader,
		IAuditCreator auditCreator,
		IUnitOfWork unitOfWork,
		IDietPreparationLogger logger,
		IMapper mapper)
	{
		_dietRequestRepository = dietRequestRepository;
		_dietRequestReader = dietRequestReader;
		_auditCreator = auditCreator;
		_unitOfWork = unitOfWork;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<bool> DeleteAsync(int requestId)
		=> await _dietRequestRepository.DeleteAsync(requestId);

	public async Task<bool> DeleteAsync(int requestId, AuditCreateDto auditCreate)
	{
		try
		{
			await _unitOfWork.BeginAsync();
			var dietRequest = await _dietRequestReader.ReadFullAsync(requestId);
			var result = await _dietRequestRepository.DeleteAsync(requestId);

			var auditDto = _mapper.Map<AuditDto>(auditCreate);
			_mapper.Map(dietRequest, auditDto);
			await _auditCreator.CreateAsync(auditDto);

			await _unitOfWork.CommitAsync();
			return result;
		}
		catch (Exception exception)
		{
			_logger.Error("An exception occured during DietRequest Delete. ", exception);
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}
}