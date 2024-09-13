using DietPreparation.Models.DAO.FilterOptions;
using DietPreparation.Models.DTO;
using DietPreparation.Models.DTO.FilterOptions;
using DietPreparation.Repositories.Spaces.Interfaces;
using DietPreparation.Services.Users.Interfaces;
using MapsterMapper;

namespace DietPreparation.Services.Users;

internal class UserReader : IUserReader
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UserReader(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<IEnumerable<UserDto>> ReadAllAsync()
	{
		var userDaos = await _userRepository.ReadAllAsync();

		return _mapper.Map<IEnumerable<UserDto>>(userDaos);
	}

	public async Task<IEnumerable<UserDto>> ReadAllAsync(OrderByDto orderByDto)
	{
		var orderByDao = _mapper.Map<OrderByDao>(orderByDto);

		var userDaos = await _userRepository.ReadAllAsync(orderByDao);

		return _mapper.Map<IEnumerable<UserDto>>(userDaos);
	}

	public async Task<UserDto?> ReadAsync(string userId)
	{
		var userDao = await _userRepository.ReadAsync(userId);

		return userDao is not null ? _mapper.Map<UserDto>(userDao) : null;
	}

	public async Task<UserDto?> FindAsync(string userName)
	{
		var userDao = await _userRepository.FindAsync(userName);

		return userDao is not null ? _mapper.Map<UserDto>(userDao) : null;
	}
}