using Application.Comman;
using Application.DTOs;
using Application.Features.Users.Queries;
using Application.Services;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
    public class GetUserByEmailHandler
        : IRequestHandler<GetUserByEmail, ApiResponse<UserDto?>>
    {
        private readonly IUserRepositoryV2 _userRepository;
        private readonly ICurrentUserService _currentUser;

        public GetUserByEmailHandler(
            IUserRepositoryV2 userRepository,
            ICurrentUserService currentUser)
        {
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        public async Task<ApiResponse<UserDto?>> Handle(
            GetUserByEmail request,
            CancellationToken cancellationToken)
        {
            // Admin can access any email
            if (_currentUser.Role != "Admin" &&
                !string.Equals(
                    _currentUser.Email,
                    request.email,
                    StringComparison.OrdinalIgnoreCase))
            {
                return new ApiResponse<UserDto?>
                {
                    Success = false,
                    Message = "Access denied.",
                    Errors = new List<string>
                {
                    "You can only access your own profile."
                }
                };
            }

            var user = await _userRepository.GetByEmailAsync(request.email);

            if (user == null)
            {
                return new ApiResponse<UserDto?>
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            return new ApiResponse<UserDto?>
            {
                Success = true,
                Message = "User retrieved successfully.",
                Data = new UserDto
                {
                    Id = user.Id,
                    Name = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    Age = user.Age
                }
            };
        }
    }
}
