using System.ComponentModel.DataAnnotations;

namespace WebApiCase1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength =1)]
        public string Name { get; set; }
        
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        
        public bool InStock { get; set; }
    }
}
