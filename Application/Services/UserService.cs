using Application.DTOs;
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
            var userDtos = new List<UserDto>();
            return userDtos = users.Select(user => new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            }).ToList();
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var users = await _userRepository.GetAllUsersAsync(); // Get all users synchronously
            var user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            var userDto = new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            };
            return userDto;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var users = await _userRepository.GetAllUsersAsync(); // Get all users synchronously
            var user = users.FirstOrDefault(u => u.Id == userId);
            var userDto = new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            };
            return userDto;

        }

        public async Task<List<UserDto>> GetUsersByAgeRangeAsync(int minAge, int maxAge)
        {
            var users = await _userRepository.GetAllUsersAsync(); // Get all users synchronously
            var filteredUsers = users.Where(u => u.Age >= minAge && u.Age <= maxAge).ToList();
            return filteredUsers.Select(user => new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            }).ToList();
        }

    }
}
