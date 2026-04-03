using Application.Comman;
using Application.Features.Leave.Policies;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Leave.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestHandler : IRequestHandler<CreateLeaveRequestCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLeaveRequestHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            // 1️⃣ Get LeaveType
            var leaveType = await _unitOfWork.LeaveTypes.GetByIdAsync(request.LeaveTypeId);

            if (leaveType == null || !leaveType.IsActive)
                return Result<int>.Failure(new List<string> { "Invalid or inactive leave type" });

            // 2️⃣ Calculate Days
            var days = (request.ToDate - request.FromDate).Days + 1;

            // 3️⃣ Get Used Balance
            var usedBalance = (await _unitOfWork.LeaveRequests.GetAllAsync())
                .Where(x => x.EmployeeId == request.EmployeeId &&
                            x.LeaveTypeId == request.LeaveTypeId &&
                            x.Status == StatusEnum.Approved)
                .Sum(x => x.Days);

            // 4️⃣ Create Entity
            var entity = new LeaveRequest
            {
                EmployeeId = request.EmployeeId,
                LeaveTypeId = request.LeaveTypeId,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                Days = days,
                Reason = request.Reason,
                HasAttachment = request.HasAttachment,
                Status = StatusEnum.Pending,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = request.EmployeeId.ToString()
            };

            // 5️⃣ Apply Policy 🔥
            var policy = LeavePolicyFactory.Resolve(leaveType.Code);

            var validation = await policy.ValidateAsync(entity, leaveType, usedBalance);

            if (!validation.IsValid)
                return Result<int>.Failure(validation.Errors);

            // 6️⃣ Overlap Check
            if (!leaveType.AllowOverlapRequest)
            {
                var hasOverlap = (await _unitOfWork.LeaveRequests.GetAllAsync())
                    .Any(x =>
                        x.EmployeeId == request.EmployeeId &&
                        x.Status != StatusEnum.Rejected &&
                        x.FromDate <= request.ToDate &&
                        x.ToDate >= request.FromDate
                    );

                if (hasOverlap)
                    return Result<int>.Failure(new List<string> { "Overlapping leave request exists" });
            }

            // 7️⃣ Save
            await _unitOfWork.LeaveRequests.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return Result<int>.Success(entity.ID);
        }
    }
}