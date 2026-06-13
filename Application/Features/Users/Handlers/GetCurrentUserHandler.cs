using Application.Comman;
using Application.DTOs;
using Application.Features.Users.Queries;
using Application.Services;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
    public class GetCurrentUserHandler
    : IRequestHandler<GetCurrentUserQuery, ApiResponse<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUser;
        private readonly IMapper _mapper;

        public GetCurrentUserHandler(
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUser,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserDto>> Handle(
         GetCurrentUserQuery request,
         CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository
                .GetByEmailAsync(_currentUser.Email);

            if (user == null)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            return new ApiResponse<UserDto>
            {
                Success = true,
                Message = "User retrieved successfully.",
                Data = _mapper.Map<UserDto>(user)
            };
        }
    }
}
