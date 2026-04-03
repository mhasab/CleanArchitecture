using Application.Features.Leave.Common.Models;
using Domain.Entities;

namespace Application.Features.Leave.Policies
{
    public class GeneralLeavePolicy : ILeavePolicy
    {
        public Task<ValidationResult> ValidateAsync(
            LeaveRequest request,
            LeaveType leaveType,
            int usedBalance)
        {
            var result = new ValidationResult();
            var today = DateTime.UtcNow.Date;

            // 🔴 Attachment
            if (leaveType.RequiresAttachment && !request.HasAttachment)
                result.Errors.Add("Attachment is required");

            // 🔴 Future
            if (!leaveType.AllowFutureRequest && request.FromDate > today)
                result.Errors.Add("Future leave not allowed");

            if (leaveType.AllowFutureRequest &&
                leaveType.MaxFutureRequestDays.HasValue &&
                (request.FromDate - today).Days > leaveType.MaxFutureRequestDays)
            {
                result.Errors.Add("Exceeded max future request days");
            }

            // 🔴 Backdated
            if (!leaveType.AllowPreviousRequest && request.FromDate < today)
                result.Errors.Add("Backdated leave not allowed");

            if (leaveType.AllowPreviousRequest &&
                leaveType.MaxPreviousRequestDays.HasValue &&
                (today - request.FromDate).Days > leaveType.MaxPreviousRequestDays)
            {
                result.Errors.Add("Exceeded max backdated days");
            }

            // 🔴 Balance
            var total = usedBalance + request.Days;

            if (!leaveType.AllowNegativeBalancePerYear &&
                total > leaveType.DefaultBalance)
            {
                result.Errors.Add("Leave balance exceeded");
            }

            if (leaveType.AllowNegativeBalancePerYear &&
                leaveType.MaxNegativeBalanceDays.HasValue &&
                total > leaveType.DefaultBalance + leaveType.MaxNegativeBalanceDays)
            {
                result.Errors.Add("Exceeded max negative balance");
            }

            // 🔴 Consecutive
            if (!leaveType.AllowConsecutiveDays && request.Days > 1)
                result.Errors.Add("Consecutive days not allowed");

            if (leaveType.AllowConsecutiveDays &&
                leaveType.MaxConsecutiveDays.HasValue &&
                request.Days > leaveType.MaxConsecutiveDays)
            {
                result.Errors.Add("Exceeded max consecutive days");
            }

            // 🔴 Half day
            if (!leaveType.AllowHalfDayRequest && request.Days < 1)
                result.Errors.Add("Half day not allowed");

            // ✅ Final result
            result.IsValid = !result.Errors.Any();
            result.Message = result.IsValid ? "Validation successful" : "Validation failed";

            return Task.FromResult(result);
        }
    }
}