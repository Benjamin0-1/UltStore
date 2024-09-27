/*using MediatR;
using UltStore.Domain.Entities;

namespace UltStore.Application.Core.Authentication.Queries
{
    public class GetProfile: IRequest<User> // user will see their profile info
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // constructor
        public GetProfile(string email, string firstName, string lastName)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
*/  

using MediatR;
using UltStore.Domain.Entities;
namespace UltStore.Application.Core.Authentication.Queries
{
    public class GetProfile : IRequest<User>
    {
        public string Email { get; }

        public GetProfile(string email)
        {
            Email = email;
        }
    }
}