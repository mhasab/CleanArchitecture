using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string Email { get; }
        string Role { get; }
    }
}
