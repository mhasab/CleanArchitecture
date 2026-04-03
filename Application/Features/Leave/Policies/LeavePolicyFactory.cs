using Domain.Enums;

namespace Application.Features.Leave.Policies
{
    public class LeavePolicyFactory
    {
        public static ILeavePolicy Resolve(LeaveTypeEnum code)
        {
            return new GeneralLeavePolicy();

        }
    }
}
