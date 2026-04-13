using Application.DTOs;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
    public class GetUserByEmailHandler : IRequestHandler<Queries.GetUserByEmail, UserDto?>
    {
        private readonly IUserRepositoryV2 _userRepository;

        public GetUserByEmailHandler(IUserRepositoryV2 userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> Handle(Queries.GetUserByEmail request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.email);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email
            };
        }
    }
}
