using System.ComponentModel.DataAnnotations;

namespace UltStore.Domain.Entities
{
    public class Product
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }
        
    }
}