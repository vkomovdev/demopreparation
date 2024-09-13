using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.DietRequests.Interfaces;

public interface IDietRequestCloner : IClone<int, DietRequestDto>
{
}