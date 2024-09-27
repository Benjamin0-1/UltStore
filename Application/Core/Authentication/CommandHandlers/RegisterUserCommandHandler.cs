using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UltStore.Application.Abstractions.Authentication;
using UltStore.Application.Core.Authentication.Commands;

namespace UltStore.Application.Core.Authentication.CommandHandlers
{
   public class RegisterUserCommandHandler : IRequestHandler<RegisterCommand, bool>
   {
        private readonly IAuthenticationRepository _authenticationRepository;

        public RegisterUserCommandHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationRepository.RegisterUserAsync(request.FirstName, request.LastName, request.Email, request.Password); 
        }
   }
}