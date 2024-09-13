using DietPreparation.Models.DTO;

namespace DietPreparation.Services.PWOs.Interfaces;

public interface IPwoCloser
{
	Task CloseAsync(PwoCloseDto model);
}
