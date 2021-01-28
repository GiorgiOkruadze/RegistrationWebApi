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
