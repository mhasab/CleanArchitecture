using Application.Features.Leave.Common.Models;
using Domain.Entities;

namespace Application.Features.Leave.Policies
{
    internal class SickLeavePolicy : ILeavePolicy
    {
        public Task<ValidationResult> ValidateAsync(LeaveRequest request, LeaveType leaveType, int usedBalance)
        {
            throw new NotImplementedException();
        }
    }
}
