using DietPreparation.Models.DTO;

namespace DietPreparation.Services.PWOs.Interfaces;

public interface IPwoCreator
{
	Task CreateWorkOrderAsync(CreateBatchDto model);
}
