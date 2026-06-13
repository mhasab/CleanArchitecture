using Application.Comman;
using Application.DTOs;
using Application.Features.Users.Queries;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
    public class GetAllUsersHandler
     : IRequestHandler<GetAllUsers, ApiResponse<List<UserDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUser;

        public GetAllUsersHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ICurrentUserService currentUser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<ApiResponse<List<UserDto>>> Handle(
    GetAllUsers request,
    CancellationToken cancellationToken)
        {
            if (_currentUser.Role != "Admin")
            {
                return new ApiResponse<List<UserDto>>
                {
                    Success = false,
                    Message = "Access denied.",
                    Errors = new List<string>
            {
                "Only admins can access this endpoint."
            }
                };
            }

            var users = await _unitOfWork.UserRepository.GetAllAsync();

            return new ApiResponse<List<UserDto>>
            {
                Success = true,
                Message = "Users retrieved successfully.",
                Data = _mapper.Map<List<UserDto>>(users)
            };
        }
    }
}
