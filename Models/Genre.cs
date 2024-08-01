using System.ComponentModel.DataAnnotations;

namespace WebApiCase1.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
