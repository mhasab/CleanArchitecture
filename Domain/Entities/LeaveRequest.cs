using Domain.Enums;

namespace Domain.Entities
{
    public class LeaveRequest : BaseEntity
    {
        public int EmployeeId { get; set; }

        public int LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public int Days { get; set; }

        public string? Reason { get; set; }

        public bool HasAttachment { get; set; }

        public StatusEnum Status { get; set; }
    }
}