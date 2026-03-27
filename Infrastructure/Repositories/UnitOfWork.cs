using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DBContext;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<User> UserRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository = new GenericRepository<User>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}