using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Services.Common.Interfaces;

namespace DietPreparation.Services.Users.Interfaces;

public interface IUserReader : IRead<string, UserDto?>, IReadAll<UserDto>
{
	Task<IEnumerable<UserDto>> ReadAllAsync(OrderByDto orderBy);
	Task<UserDto?> FindAsync(string userName);
}
