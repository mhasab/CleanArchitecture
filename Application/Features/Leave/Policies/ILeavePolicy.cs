using Application.Features.Leave.Common.Models;
using Domain.Entities;

namespace Application.Features.Leave.Policies
{
    public interface ILeavePolicy
    {
        Task<ValidationResult> ValidateAsync(
            LeaveRequest request,
            LeaveType leaveType,
            int usedBalance);
    }
}