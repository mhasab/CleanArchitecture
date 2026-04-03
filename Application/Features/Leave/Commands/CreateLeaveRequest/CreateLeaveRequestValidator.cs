using FluentValidation;

namespace Application.Features.Leave.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        public CreateLeaveRequestValidator()
        {
            RuleFor(x => x.EmployeeId)
                .GreaterThan(0);

            RuleFor(x => x.LeaveTypeId)
                .GreaterThan(0);

            RuleFor(x => x.FromDate)
                .LessThanOrEqualTo(x => x.ToDate);

            RuleFor(x => x.ToDate)
                .GreaterThanOrEqualTo(x => x.FromDate);
        }
    }
}