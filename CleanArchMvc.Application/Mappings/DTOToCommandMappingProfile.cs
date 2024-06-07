using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings;

public class DtoToCommandMappingProfile : Profile {
    public DtoToCommandMappingProfile() {
        CreateMap<ProductDto, ProductCreateCommand>();
        CreateMap<ProductDto, ProductUpdateCommand>();
    }
}