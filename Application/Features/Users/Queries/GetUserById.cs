using Application.DTOs;
using MediatR;
namespace Application.Features.Users.Queries
{
    public record GetUserById(int Id) : IRequest<UserDto?>;
}
