using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UltStore.Application.Abstractions.Authentication;
using UltStore.Application.Core.Authentication.Commands;

namespace UltStore.Application.Core.Authentication.CommandHandlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public LoginUserCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationRepository.LoginUserAsync(request.Email, request.Password);
        }
    }
}