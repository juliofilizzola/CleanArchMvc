using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.Application.Mappings
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile() {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}