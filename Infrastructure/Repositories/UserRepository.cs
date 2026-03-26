using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>
        {
            new User(1, "Mohamed", "Ali", 30,"moh.ali@gmail.com"),
            new User(2, "Sara", "Ahmed", 25,"sara.ahmed@gmail.com"),
            new User(3, "Omar", "Hassan", 28,"om.hassan@gmail.com"),
            new User(4, "Laila", "Youssef", 18,"lil.youssef@gmail.com")
        };

        public async Task<List<User>> GetAllUsersAsync()
        {
            await Task.Delay(200);
            return _users;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            await Task.Delay(100);

            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            await Task.Delay(100);

            return _users.FirstOrDefault(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<List<User>> GetByAgeRangeAsync(int minAge, int maxAge)
        {
            await Task.Delay(100);

            return _users
                .Where(u => u.Age >= minAge && u.Age <= maxAge)
                .ToList();
        }

        public async Task<User> AddUserAsync(User user)
        {
            await Task.Delay(500);
            _users.Add(user);
            return user;
        }
    }
}