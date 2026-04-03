using Application.Comman;
using MediatR;
namespace Application.Features.Leave.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : IRequest<Result<int>>
    {
        public int EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string? Reason { get; set; }

        public bool HasAttachment { get; set; }
    }
}
