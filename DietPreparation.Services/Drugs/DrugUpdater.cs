using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Drugs.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Drugs;

internal class DrugUpdater : IDrugUpdater
{
	private readonly IDrugsRepository _drugRepository;
	private readonly IMapper _mapper;

	public DrugUpdater(IDrugsRepository drugRepository, IMapper mapper)
	{
		_drugRepository = drugRepository;
		_mapper = mapper;
	}

	public async Task<DrugUpdateDto> UpdateAsync(DrugUpdateDto entity)
	{
		var id = await _drugRepository.DrugUpdate(entity);

		entity.Id = id is null ? entity.Id : int.Parse(id);

		return entity;
	}
}
