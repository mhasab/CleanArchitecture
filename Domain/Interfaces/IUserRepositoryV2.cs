using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepositoryV2 : IGenericRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
