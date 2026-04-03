using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DBContext;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGenericRepository<User> UserRepository { get; }
        public IGenericRepository<LeaveRequest> LeaveRequests { get; }
        public IGenericRepository<LeaveType> LeaveTypes { get; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            UserRepository = new GenericRepository<User>(context);
            LeaveRequests = new GenericRepository<LeaveRequest>(context);
            LeaveTypes = new GenericRepository<LeaveType>(context);
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