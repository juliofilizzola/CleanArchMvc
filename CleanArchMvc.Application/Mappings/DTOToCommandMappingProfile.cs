using AutoMapper;
using CleanArchMvc.Application.DTO;
using CleanArchMvc.Application.Products.Commands;

namespace CleanArchMvc.Application.Mappings;

public class DTOToCommandMappingProfile : Profile {
    public DTOToCommandMappingProfile() {
        CreateMap<ProductDto, ProductCreateCommand>().ReverseMap();
        CreateMap<ProductCreateCommand, ProductDto>().ReverseMap();
        CreateMap<ProductDto, ProductUpdateCommand>().ReverseMap();
        CreateMap<ProductUpdateCommand, ProductDto>().ReverseMap();
    }
}