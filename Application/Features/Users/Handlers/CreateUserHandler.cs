using Application.DTOs;
using Application.Features.Users.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using AutoMapper;

namespace Application.Features.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(/*IUserRepository userRepository*/IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //var users = await _unitOfWork.UserRepository.GetAllAsync();
            //var newId = users != null && users.Count() > 0 ? users.Max(u => u.Id) : 0;

            var user = _mapper.Map<User>(request);
            //user.Id = newId + 1;

            await _unitOfWork.UserRepository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync();
            var createdUser = await _unitOfWork.UserRepository.GetByIdAsync(user.Id);
            if (createdUser != null)
            {
                return _mapper.Map<UserDto>(createdUser);
            }

            return null;
        }
    }
}
