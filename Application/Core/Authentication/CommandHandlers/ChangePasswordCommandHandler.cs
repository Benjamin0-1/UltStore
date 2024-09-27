using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UltStore.Application.Abstractions.Authentication;
using UltStore.Application.Core.Authentication.Commands;

namespace UltStore.Application.Core.Authentication.CommandHandlers
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public ChangePasswordCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationRepository.ChangePasswordAsync(request.Email, request.OldPassword, request.NewPassword);
        }
    }
}
