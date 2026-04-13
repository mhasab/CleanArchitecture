using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepositoryV2 : GenericRepository<User>, IUserRepositoryV2
    {
        protected readonly AppDbContext _context;
        public UserRepositoryV2(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
