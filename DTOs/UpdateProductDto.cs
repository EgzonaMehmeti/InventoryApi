using System.ComponentModel.DataAnnotations;

namespace InventoryApi.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Range(0.01, 9999999999999999.99)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }

        [MaxLength(100)]
        public string? Category { get; set; }
    }
}
