using System.ComponentModel.DataAnnotations;


namespace UltStore.Domain.Entities
{
    public class LoginHistory
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public DateTime LoginTime { get; set; } = DateTime.Now;
        
        [Required]
        public Guid UserId { get; set; } // reference to User
        [Required]
        public required User User { get; set; }
    }
}