using Application.DTOs;
using Application.Features.Users.Queries;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Users.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDto>>(users);
            return usersDtos;

        }
    }
}
