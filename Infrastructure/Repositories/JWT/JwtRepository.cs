using UltStore.Application.Abstractions.JWT;
using UltStore.Persistance;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UltStore.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using UltStore.Domain.Dtos;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;


namespace UltStore.Infrastructure.Repositories.JwtRepository
{

    public class JwtRepository : IJwtRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;

        public JwtRepository(ApplicationDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _secretKey = configuration["JwtSettings:SecretKey"];
            _issuer = configuration["JwtSettings:Issuer"];
            _audience = configuration["JwtSettings:Audience"];
        }

        public async Task<string> GenerateRefreshTokenAsync(int UserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user == null)
            {
                return "User is null";
            }

            return "RefreshToken"; // return the refresh token
            
            
        }

        public async Task<string> GenerateAccessTokenAsync(int UserId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == UserId);
            if (user == null)
            {
                return "User is null";
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            // get the secret key from appsettings
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")); 
            var creds = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token); 
           }

        


          public Task<bool> ValidateRefreshTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // grab the secret key from appsettings
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")); 
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    ValidateLifetime = false
                }, out SecurityToken validatedToken);

                return Task.FromResult(true);
            }
            catch (System.Exception)
            {
                return Task.FromResult(false);
            }
        }

        public Task<bool> ValidateAccessTokenAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // grab the secret key from appsettings
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "yourdomain.com",
                    ValidAudience = "yourdomain.com",
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                return Task.FromResult(true);
            }
            catch (System.Exception)
            {
               
                return Task.FromResult(false); 
            }
        }
    }

    }

