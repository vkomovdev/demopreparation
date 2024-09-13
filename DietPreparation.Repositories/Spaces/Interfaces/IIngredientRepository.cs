using DietPreparation.Models.DAO;
using DietPreparation.Repositories.Common.Interfaces;

namespace DietPreparation.Repositories.Spaces.Interfaces;

public interface IIngredientRepository : IReadAllRecord<IngredientDao>
{
}