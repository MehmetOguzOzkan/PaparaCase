using AutoMapper;
using WebApiCase1.DTOs.Requests;
using WebApiCase1.DTOs.Responses;
using WebApiCase1.Models;

namespace WebApiCase1.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<Genre, GenreResponse>();
            CreateMap<GenreRequest, Genre>();
        }
    }
}
