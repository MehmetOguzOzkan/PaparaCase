using System.ComponentModel.DataAnnotations;

namespace WebApiCase1.DTOs.Requests
{
    public class ProductRequest
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool InStock { get; set; }
    }
}
