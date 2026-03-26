using AutoMapper;
using Application.Features.Users.Commands;
using Domain.Entities;

namespace Application.Features.Users.Mapping.Resolvers
{
    public class FirstNameResolver : IValueResolver<CreateUserCommand, User, string>
    {
        public string Resolve(CreateUserCommand source, User destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrWhiteSpace(source.Name))
                return null;

            return source.Name.Split(' ', 2)[0];
        }
    }
}