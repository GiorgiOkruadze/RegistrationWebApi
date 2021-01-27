using AutoMapper;
using MediatR;
using Registration.DomainCore.Services.Abstractions;
using Registration.DomainModels.Models;
using Registration.WebApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.WebApi.CommandHandlers
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
