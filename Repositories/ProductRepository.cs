using Microsoft.EntityFrameworkCore;
using WebApiCase1.Data;
using WebApiCase1.Models;

namespace WebApiCase1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        // Repository constructor, DbContext injection
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Retrieve all products
        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        // Retrieve a product by ID
        public Product GetById(int id) => _context.Products.Find(id);

        // Add a new product
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // Update an existing product
        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete a product
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        // List and sort products
        public IEnumerable<Product> List(string name, string sortField, string sortOrder)
        {
            var query = _context.Products.AsQueryable();

            // Name filter
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            }

            // Sorting
            switch (sortField?.ToLower())
            {
                case "price":
                    query = sortOrder?.ToLower() == "desc" ? query.OrderByDescending(p => p.Price) : query.OrderBy(p => p.Price);
                    break;
                case "name":
                    query = sortOrder?.ToLower() == "desc" ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name);
                    break;
                default:
                    query = sortOrder?.ToLower() == "desc" ? query.OrderByDescending(p => p.Id) : query.OrderBy(p => p.Id);
                    break;
            }

            return query.ToList();
        }

    }
}
