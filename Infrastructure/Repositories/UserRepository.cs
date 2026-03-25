using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        public async Task<List<User>> GetAllUsersAsync()
        {
            await Task.Delay(500); // Simulate async operation
            return new List<User>
            {
                new User(1, "Mohamed", "Ali", 30,"moh.ali@gmail.com"),
                new User(2, "Sara", "Ahmed", 25,"sara.ahmed@gmail.com"),
                new User(3, "Omar", "Hassan", 28,"om.hassan@gmail.com"),
                new User(4, "Laila", "Youssef", 18,"lil.youssef@gmail.com")
            };
        }

    }
}
