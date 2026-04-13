using Application.Comman;
using Application.Features.Login.Commands;
using Application.Services;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Login.Handlers
{
    public class LoginHandler : IRequestHandler<LoginCommand, Result<string>>
    {
        private readonly IUserRepositoryV2 _userRepository;
        private readonly IJwtTokenGenerator _jwt;

        public LoginHandler(IUserRepositoryV2 userRepository, IJwtTokenGenerator jwt)
        {
            _userRepository = userRepository;
            _jwt = jwt;
        }

        public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.email);

            if (user == null || user.Password != request.password)
            {
                return Result<string>.Failure(new List<string>
                {
                    "Invalid email or password"
                });
            }

            var token = _jwt.GenerateToken(user);

            return Result<string>.Success(token);
        }
    }
}