using MediatR;
using UltStore.Domain.Entities;
using UltStore.Application.Abstractions.Authentication;
using System.Threading;
using System.Threading.Tasks;

namespace UltStore.Application.Core.Authentication.Queries
{
    public class GetProfileQueryHandler : IRequestHandler<GetProfile, User>
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public GetProfileQueryHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<User> Handle(GetProfile request, CancellationToken cancellationToken)
        {
            // Fetch user profile; can return null if not found
            var userProfile = await _authenticationRepository.GetProfileByEmailAsync<User>(request.Email);
            return userProfile; // Return null if user not found
        }
    }
}
