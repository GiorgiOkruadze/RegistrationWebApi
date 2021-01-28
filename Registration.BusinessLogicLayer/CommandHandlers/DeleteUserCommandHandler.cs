using AutoMapper;
using MediatR;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Registration.DataAccessLayer.Services.Abstractions;

namespace Registration.BusinessLogicLayer.CommandHandlers
{
    public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommand,bool>
    {
        private readonly IUserRepository _userRepo = default;

        public DeleteUserCommandHandler(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepo.DeleteUserAsync(request.UserId);
        }
    }
}
