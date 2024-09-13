using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;

namespace DietPreparation.Services.Drugs.Interfaces;

public interface IDrugFilter : ISortLimited<DrugsItemDto, IOrderBy, IPagination>
{
}
