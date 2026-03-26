using Application.DTOs;
using Application.Features.Users.Commands;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

            CreateMap<CreateUserCommand, User>()
                 .ForCtorParam("id", opt => opt.MapFrom(src => 0))
                 .ForCtorParam("firstName", opt => opt.MapFrom(src =>
                     string.IsNullOrWhiteSpace(src.Name)
                         ? null
                         : src.Name.Split(' ', 2)[0]))
                 .ForCtorParam("lastName", opt => opt.MapFrom(src =>
                     string.IsNullOrWhiteSpace(src.Name) || !src.Name.Contains(' ')
                         ? string.Empty
                         : src.Name.Split(' ', 2)[1]))
                 .ForCtorParam("age", opt => opt.MapFrom(src => src.Age))
                 .ForCtorParam("email", opt => opt.MapFrom(src => src.Email));
        }
    }
}