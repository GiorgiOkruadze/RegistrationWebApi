using AutoMapper;
using MediatR;
using Registration.BusinessLogicLayer.Authentication.Abstraction;
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
    public class LogInCommandHandler : IRequestHandler<LogInCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;

        public LogInCommandHandler(IUserRepository userRepo, IMapper mapper, IJwtAuthenticationManager authenticationManager)
        {
            _mapper = mapper;
            _userRepo = userRepo;

        }

        public async Task<string> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var logInInfo = _mapper.Map<LogInUser>(request);
            var result =  await _userRepo.LogInAsync(logInInfo);
            return  _authenticationManager.Authenticate(result,request.Email);
        }
    }
}
