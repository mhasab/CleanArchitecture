using Domain.Entities;

namespace Application.Services
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
