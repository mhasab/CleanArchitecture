using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepositoryV2 UserRepository { get; }
        IGenericRepository<LeaveRequest> LeaveRequests { get; }
        IGenericRepository<LeaveType> LeaveTypes { get; }
        Task<int> SaveChangesAsync();
    }
}
