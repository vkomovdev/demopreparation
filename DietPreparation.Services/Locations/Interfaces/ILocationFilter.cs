using DietPreparation.Filter.Interfaces;
using DietPreparation.Filter.Options;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;

namespace DietPreparation.Services.Drugs.Interfaces;

public interface ILocationFilter : ISortLimited<LocationsItemDto, IOrderBy, IPagination>, IFilter<LocationDto, LocationFilterDto>
{
}
