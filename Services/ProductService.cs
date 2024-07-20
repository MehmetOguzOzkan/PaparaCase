using AutoMapper;
using WebApiCase1.DTOs.Requests;
using WebApiCase1.DTOs.Responses;
using WebApiCase1.Models;
using WebApiCase1.Repositories;

namespace WebApiCase1.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        // Constructor to inject the repository and mapper dependencies
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        // Get all products and map them to ProductResponse
        public IEnumerable<ProductResponse> GetAll()
        {
            var products = _productRepository.GetAll();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        // Get a product by ID and map it to ProductResponse
        public ProductResponse GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product == null ? null : _mapper.Map<ProductResponse>(product);
        }

        // Add a new product by mapping ProductRequest to Product
        public ProductResponse Add(ProductRequest productRequest)
        {
            var product = _mapper.Map<Product>(productRequest);
            _productRepository.Add(product);
            return _mapper.Map<ProductResponse>(product);
        }

        // Update an existing product by mapping ProductRequest to the existing Product
        public bool Update(int id, ProductRequest productRequest)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
                return false;

            // Map the updated values from ProductRequest to the existing product
            var product = _mapper.Map(productRequest, existingProduct);
            _productRepository.Update(product);
            return true;
        }

        // Delete a product by ID
        public bool Delete(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null)
                return false;

            _productRepository.Delete(id);
            return true;
        }

        // List products with optional filtering, sorting, and mapping to ProductResponse
        public IEnumerable<ProductResponse> List(string name, string sortField, string sortOrder)
        {
            var products = _productRepository.List(name, sortField, sortOrder);
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }
    }
}
