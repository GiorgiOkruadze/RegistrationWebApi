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
    public class LogInCommandHandler : IRequestHandler<LogInCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo = default;

        public LogInCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            var logInInfo = _mapper.Map<LogInUser>(request);
            return await _userRepo.LogInAsync(logInInfo);
        }
    }
}
