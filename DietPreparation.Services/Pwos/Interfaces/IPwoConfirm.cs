using DietPreparation.Models.DTO;

namespace DietPreparation.Services.PWOs.Interfaces;

public interface IPwoConfirm
{
	Task ConfirmAsync(PwoConfirmDto model);
}