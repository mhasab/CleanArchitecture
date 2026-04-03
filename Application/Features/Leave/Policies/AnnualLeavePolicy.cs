using Application.Features.Leave.Common.Models;
using Domain.Entities;

namespace Application.Features.Leave.Policies
{
    public class AnnualLeavePolicy : ILeavePolicy
    {
        public Task<ValidationResult> ValidateAsync(
            LeaveRequest request,
            LeaveType leaveType,
            int usedBalance)
        {
            var result = new ValidationResult();
            var today = DateTime.UtcNow.Date;

            // 🔴 Future request
            if (!leaveType.AllowFutureRequest && request.FromDate > today)
            {
                result.AddError("Future leave not allowed");
            }

            if (leaveType.AllowFutureRequest &&
                leaveType.MaxFutureRequestDays.HasValue &&
                (request.FromDate - today).Days > leaveType.MaxFutureRequestDays)
            {
                result.AddError("Exceeded max future request days");
            }

            // 🔴 Balance check
            var total = usedBalance + request.Days;

            if (!leaveType.AllowNegativeBalancePerYear &&
                total > leaveType.DefaultBalance)
            {
                result.AddError("Leave balance exceeded");
            }

            if (leaveType.AllowNegativeBalancePerYear &&
                leaveType.MaxNegativeBalanceDays.HasValue &&
                total > leaveType.DefaultBalance + leaveType.MaxNegativeBalanceDays)
            {
                result.AddError("Exceeded max negative balance");
            }

            // 🔴 Consecutive days
            if (!leaveType.AllowConsecutiveDays && request.Days > 1)
            {
                result.AddError("Consecutive leave not allowed");
            }

            if (leaveType.AllowConsecutiveDays &&
                leaveType.MaxConsecutiveDays.HasValue &&
                request.Days > leaveType.MaxConsecutiveDays)
            {
                result.AddError("Exceeded max consecutive days");
            }

            // 🔴 Attachment (optional for annual)
            if (leaveType.RequiresAttachment && !request.HasAttachment)
            {
                result.AddError("Attachment is required");
            }

            // ✅ Final result
            result.IsValid = !result.Errors.Any();
            result.Message = result.IsValid ? "Valid" : "Validation failed";

            return Task.FromResult(result);
        }
    }
}