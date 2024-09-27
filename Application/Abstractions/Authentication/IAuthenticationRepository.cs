using UltStore.Domain.Entities;

namespace UltStore.Application.Abstractions.Authentication
{
    public interface IAuthenticationRepository
    {
        Task<bool> RegisterUserAsync(string firstName, string lastName, string email, string password);
        Task<string> LoginUserAsync(string email, string password);
        Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
     
        Task<T> GetProfileByEmailAsync<T>(string email);
    }
}