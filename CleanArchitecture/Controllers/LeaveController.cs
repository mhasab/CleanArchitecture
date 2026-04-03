using Application.Features.Leave.Commands.CreateLeaveRequest;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.DBContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly AppDbContext _context;

        public LeaveController(IMediator mediator, AppDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("request")]
        public async Task<IActionResult> CreateLeaveRequest(CreateLeaveRequestCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(new
                {
                    success = false,
                    errors = result.Errors
                });

            return Ok(new
            {
                success = true,
                data = result.Value
            });
        }
        [HttpPost("seed")]
        public async Task<IActionResult> Seed()
        {
            var leaveTypes = new List<LeaveType>
    {
        new LeaveType
        {
            Code = LeaveTypeEnum.Annual,
            LeaveName = "Annual Leave",
            DefaultBalance = 21,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        },
        new LeaveType
        {
            Code = LeaveTypeEnum.Sick,
            LeaveName = "Sick Leave",
            DefaultBalance = 10,
            RequiresAttachment = true,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = "System"
        }
    };

            await _context.LeaveTypes.AddRangeAsync(leaveTypes);
            await _context.SaveChangesAsync();

            return Ok("Seeded");
        }
    }
}