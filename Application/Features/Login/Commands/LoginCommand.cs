using Application.Comman;
using MediatR;

namespace Application.Features.Login.Commands
{
    public record LoginCommand(string email, string password) : IRequest<Result<string>>;
}
