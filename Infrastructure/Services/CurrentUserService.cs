using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId
        {
            get
            {
                var id = _httpContextAccessor.HttpContext?
                    .User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ??
                    _httpContextAccessor.HttpContext?
                    .User.FindFirst("sub")?.Value;

                return int.Parse(id!);
            }
        }

        public string Email =>
            _httpContextAccessor.HttpContext?
                .User.FindFirst(ClaimTypes.Email)?.Value
            ??
            _httpContextAccessor.HttpContext?
                .User.FindFirst("email")?.Value
            ??
            string.Empty;

        public string Role =>
            _httpContextAccessor.HttpContext?
                .User.FindFirst(ClaimTypes.Role)?.Value
            ??
            string.Empty;
    }
}