using Application.DTOs;
using Application.Features.Users.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUsersAsync();
            var newId = users != null && users.Count > 0 ? users.Max(u => u.Id) : 0;

            var user = _mapper.Map<User>(request);
            user.Id = newId + 1;

            var createdUser = await _userRepository.AddUserAsync(user);

            if (createdUser != null)
                return _mapper.Map<UserDto>(createdUser);

            return null;
        }
    }
}
