using DietPreparation.Data.UnitOfWork;
using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.BasalDiets.Interfaces;
using DietPreparation.Utilities.Logger;
using MapsterMapper;

namespace DietPreparation.Services.BasalDiets;

internal class BasalDietUpserter : IBasalDietUpserter
{
	private readonly IBasalDietRepository _basalDietRepository;
	private readonly IMapper _mapper;
	private readonly IUnitOfWork _unitOfWork;
	private readonly IDietPreparationLogger _logger;

	public BasalDietUpserter(
		IBasalDietRepository basalDietRepository,
		IMapper mapper,
		IUnitOfWork unitOfWork,
		IDietPreparationLogger logger)
	{
		_basalDietRepository = basalDietRepository;
		_mapper = mapper;
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<BasalDietDto> UpsertAsync(BasalDietDto entity)
	{
		try
		{
			await _unitOfWork.BeginAsync();
			var result = await _basalDietRepository.UpsertAsync(_mapper.Map<BasalDietDao>(entity));
			await _unitOfWork.CommitAsync();
			return _mapper.Map<BasalDietDto>(result);
		}
		catch (Exception exception)
		{
			_logger.Error(exception.Message, exception);
			await _unitOfWork.RollbackAsync();
			throw;
		}
	}
}
