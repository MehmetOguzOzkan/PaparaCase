using WebApiCase1.Models;
using WebApiCase1.Repositories;

namespace WebApiCase1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll() => _productRepository.GetAll();

        public Product GetById(int id) => _productRepository.GetById(id);

        public void Add(Product product) => _productRepository.Add(product);

        public void Update(Product product) => _productRepository.Update(product);

        public void Delete(int id) => _productRepository.Delete(id);

        public IEnumerable<Product> List(string name, string sortField, string sortOrder) => _productRepository.List(name, sortField, sortOrder);
    }
}
