using Domain.Enums;

namespace Domain.Entities
{
    public class LeaveType : BaseEntity
    {
        public LeaveTypeEnum Code { get; set; }

        public required string LeaveName { get; set; }

        public int DefaultBalance { get; set; } 

        public bool RequiresAttachment { get; set; }

        // Carry Forward
        public bool AllowCarryForward { get; set; }
        public int? MaxCarryForwardDays { get; set; }

        // Future Requests
        public bool AllowFutureRequest { get; set; }
        public int? MaxFutureRequestDays { get; set; }

        // Backdated Requests
        public bool AllowPreviousRequest { get; set; }
        public int? MaxPreviousRequestDays { get; set; }

        // Consecutive Days
        public bool AllowConsecutiveDays { get; set; }
        public int? MaxConsecutiveDays { get; set; }

        // Multiple Requests Per Year
        public bool AllowMultipleRequestPerYear { get; set; }
        public int? MaxMultipleRequestDays { get; set; }

        // Negative Balance
        public bool AllowNegativeBalancePerYear { get; set; }
        public int? MaxNegativeBalanceDays { get; set; }

        // Other Rules
        public bool AllowCancellation { get; set; }
        public bool AllowOverlapRequest { get; set; }
        public bool AllowHalfDayRequest { get; set; }

        public bool IsActive { get; set; }
    }
}