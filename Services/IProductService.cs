using WebApiCase1.DTOs.Requests;
using WebApiCase1.DTOs.Responses;
using WebApiCase1.Models;

namespace WebApiCase1.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAll();
        ProductResponse GetById(int id);
        ProductResponse Add(ProductRequest productRequest);
        bool Update(int id, ProductRequest productRequest);
        bool Delete(int id);
        IEnumerable<ProductResponse> List(string name, string sortField, string sortOrder);
    }
}
