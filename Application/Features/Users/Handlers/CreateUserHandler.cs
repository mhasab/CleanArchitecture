using Application.DTOs;
using Application.Features.Users.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using AutoMapper;
using Application.Comman;

namespace Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ApiResponse<UserDto>>
    {
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(/*IUserRepository userRepository*/IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UserDto>> Handle(
     CreateUserCommand request,
     CancellationToken cancellationToken)
        {
            try
            {
                var existingUser =
                    await _unitOfWork.UserRepository.GetByEmailAsync(request.Email);

                if (existingUser != null)
                {
                    return new ApiResponse<UserDto>
                    {
                        Success = false,
                        Message = "User already exists.",
                        Errors = new List<string>
                {
                    $"Email '{request.Email}' is already registered."
                }
                    };
                }

                var user = _mapper.Map<User>(request);

                await _unitOfWork.UserRepository.AddAsync(user);

                var affectedRows = await _unitOfWork.SaveChangesAsync();

                if (affectedRows <= 0)
                {
                    return new ApiResponse<UserDto>
                    {
                        Success = false,
                        Message = "Failed to create user.",
                        Errors = new List<string>
                {
                    "No records were saved to the database."
                }
                    };
                }

                return new ApiResponse<UserDto>
                {
                    Success = true,
                    Message = "User created successfully.",
                    Data = _mapper.Map<UserDto>(user)
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<UserDto>
                {
                    Success = false,
                    Message = "Unexpected error occurred.",
                    Errors = new List<string>
            {
                ex.Message
            }
                };
            }
        }
    }
}
