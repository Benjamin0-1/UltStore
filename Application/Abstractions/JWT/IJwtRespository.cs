using UltStore.Domain.Entities;
using System.Threading.Tasks;
using UltStore.Domain.Dtos;

namespace UltStore.Application.Abstractions.JWT
{
    public interface IJwtRepository
    {
        Task<string> GenerateRefreshTokenAsync(int UserId); // from : int UserId
        Task<string> GenerateAccessTokenAsync(int UserId);
        Task<bool> ValidateRefreshTokenAsync(string token);
        Task<bool> ValidateAccessTokenAsync(string token);
        //Task<int> GetUserIdFromRefreshTokenAsync(string token); // to be added
        //Task<int> GetUserIdFromAccessTokenAsync(string token);
        
    }
}

 