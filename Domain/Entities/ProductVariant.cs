using System.ComponentModel.DataAnnotations;

namespace UltStore.Domain.Entities
{
    public class ProductVariant
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; } // variant name

        [Required]
        public required decimal Price { get; set; } 
        [Required]
        public required int Stock { get; set; } 
        
        // reference to Product
        [Required]
        public Guid ProductId { get; set; }
        [Required]
        public required Product Product { get; set; }
    }
}