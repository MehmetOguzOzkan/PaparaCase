using System.ComponentModel.DataAnnotations;

namespace WebApiCase1.DTOs.Requests
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool InStock { get; set; }
    }
}
