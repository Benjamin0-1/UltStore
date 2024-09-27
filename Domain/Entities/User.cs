using System.ComponentModel.DataAnnotations;

namespace UltStore.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        public ICollection<LoginHistory>? LoginHistories { get; set; }

        // A role can have many users, a user can have one role
        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public required Role Role { get; set; }
    }
}