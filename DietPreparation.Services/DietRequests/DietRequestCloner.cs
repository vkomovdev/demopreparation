using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.DietRequests.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.DietRequests;

internal class DietRequestCloner : IDietRequestCloner
{
	private readonly IDietRequestReader _dietRequestReader;
	private readonly IDietRequestRepository _dietRequestRepository;
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;

	public DietRequestCloner(
		IDietRequestReader dietRequestReader,
		IDietRequestRepository dietRequestRepository,
		IMapper mapper,
		IUnitOfWork unitOfWork)
	{
		_dietRequestReader = dietRequestReader;
		_dietRequestRepository = dietRequestRepository;
		_mapper = mapper;
		_unitOfWork = unitOfWork;
	}

	public async Task<DietRequestDto> CloneAsync(int requestId)
	{
		try
		{
			await _unitOfWork.BeginAsync();

			await _dietRequestRepository.CloneAsync(requestId);
			var dietRequest = _mapper.Map<DietRequestDto>(await _dietRequestReader.ReadFullAsync(requestId));
			dietRequest.IsLocked = false;
			dietRequest.DateRequest = null;
			dietRequest.DateNeeded = null;

			await _unitOfWork.CommitAsync();
			return dietRequest;
		}
		catch (InvalidOperationException exception)
		{
			await _unitOfWork.RollbackAsync();
			throw exception;
		}
	}
}