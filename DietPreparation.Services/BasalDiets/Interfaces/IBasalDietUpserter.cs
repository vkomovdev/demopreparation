using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.BasalDiets.Interfaces;

public interface IBasalDietUpserter : IUpsert<BasalDietDto>
{
}