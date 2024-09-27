using System.ComponentModel.DataAnnotations;

namespace UltStore.Domain.Entities
{
    public class Role
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        // a role can have many users, a user can have one role
        public ICollection<User>? Users { get; set; }
    }
}