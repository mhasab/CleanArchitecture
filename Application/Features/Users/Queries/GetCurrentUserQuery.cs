using Application.Comman;
using Application.DTOs;
using MediatR;

namespace Application.Features.Users.Queries
{
    public record GetCurrentUserQuery()
    : IRequest<ApiResponse<UserDto>>;
}
