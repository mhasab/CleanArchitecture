using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return users.Select(MapToDto).ToList();
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
                return null;

            return MapToDto(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return null;

            return MapToDto(user);
        }

        public async Task<List<UserDto>> GetUsersByAgeRangeAsync(int minAge, int maxAge)
        {
            var users = await _userRepository.GetByAgeRangeAsync(minAge, maxAge);

            return users.Select(MapToDto).ToList();
        }

        private static UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }
    }
}
