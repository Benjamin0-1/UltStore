using Microsoft.EntityFrameworkCore;
using UltStore.Application.Abstractions.Authentication;
using UltStore.Domain.Entities;
using UltStore.Persistance;
using System.Threading.Tasks;
using BCrypt.Net;

namespace UltStore.Infrastructure.Repositories.Authentication
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthenticationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUserAsync(string firstName, string lastName, string email, string password)
        {
        // Fetch the Role object from the database
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
        if (role == null)
        {
            throw new Exception("Role not found");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = hashedPassword,
            Role = role 
        };

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return true;
    }

        public async Task<string> LoginUserAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password); // Hash passwords in production

            if (user == null)
            {
                return "Invalid credentials";
            }

            // convert guid to string
            return user.Id.ToString();
        }

        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == oldPassword); // Hash passwords in production

            if (user == null)
            {
                return false;
            }

            user.Password = newPassword; // Consider hashing passwords before saving
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<T> GetProfileByEmailAsync<T>(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
            {
                return default(T);
            }
            return (T)(object)user;
        }
    }
}
