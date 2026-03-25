using Application.DTOs;
using Domain.Interfaces;

namespace Application.Services
{
    public interface IUserService
    {
        public Task<UserDto> GetUserByIdAsync(int userId);
        public Task<List<UserDto>> GetAllUsersAsync();
        public Task<UserDto> GetUserByEmailAsync(string email);
        public Task<List<UserDto>> GetUsersByAgeRangeAsync(int minAge, int maxAge);
    }
}
