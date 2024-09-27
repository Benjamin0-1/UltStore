using System.ComponentModel.DataAnnotations;

namespace UltStore.Domain.Dtos
{
    public class UserLoginHistoryDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } // reference to User
        
        public required string Ip { get; set; }
        public required string UserAgent { get; set; }
    }
}
