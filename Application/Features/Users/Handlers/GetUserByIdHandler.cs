using Application.DTOs;
using Application.Features.Users.Queries;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
   public class GetUserByIdHandler : IRequestHandler<GetUserById, UserDto>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
                return null;
            return new UserDto
            {
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Age = user.Age
            };
        }
    }
}