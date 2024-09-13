using DietPreparation.Models.DAO;
using DietPreparation.Models.DTO;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Customers;
using DietPreparation.Services.Users.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Users;

internal class UserUpdater : IUserUpdater
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UserUpdater(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<UserDto> UpdateAsync(UserDto userDto)
	{
		var createUpdateUserDao = _mapper.Map<CreateUpdateUserDao>(userDto);

		await _userRepository.UpdateAsync(createUpdateUserDao);

		return userDto;
	}
}
