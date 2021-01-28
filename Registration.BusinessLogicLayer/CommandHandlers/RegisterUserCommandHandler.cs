using AutoMapper;
using MediatR;
using Registration.BusinessLogicLayer.Commands;
using Registration.DataAccessLayer.Models;
using Registration.DataAccessLayer.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.CommandHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo = default;

        public RegisterUserCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            return await _userRepo.RegistrationAsync(user, request.Password);
        }
    }
}
