using DietPreparation.Models.DTO;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Locations.Interfaces;

public interface ILocationReader : IReadAll<LocationDto>, IRead<int, LocationDto>
{
}
