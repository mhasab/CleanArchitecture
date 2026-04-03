using Domain.Entities;

namespace Application.policies
{

    public interface ILeavePolicy
    {
        Task ValidateAsync(LeaveRequest leaveRequest, LeaveType leaveType);
    }
}