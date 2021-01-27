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
    public class UpdateUserInfoCommandHandler:IRequestHandler<UpdateUserInfoCommand,bool>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepo = default;

        public UpdateUserInfoCommandHandler(IUserRepository userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var userInfo = _mapper.Map<UserInformation>(request);
            return await _userRepo.ChangeGeneralInformationAsync(request.UserId, userInfo);
        }
    }
}
