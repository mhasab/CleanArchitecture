using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>?> GetAllUsersAsync();
        public Task<User?> GetByIdAsync(int userId);
        public Task<User?> GetByEmailAsync(string email);
        public Task<List<User>?> GetByAgeRangeAsync(int minAge, int maxAge);
        public Task<User> AddUserAsync(User user);
    }
}
