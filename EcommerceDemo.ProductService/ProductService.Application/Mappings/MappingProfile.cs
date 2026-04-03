using AutoMapper;
using ProductService.Application.Commands.CreateProduct;
using ProductService.Application.Commands.UpdateProduct;
using ProductService.Application.DTOs;
using ProductService.Domain.Entities;

namespace ProductService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryIds, opt => opt.MapFrom(src => src.Categories.Select(c => c.Id).ToList()))
                .ForMember(dest => dest.CategoryNames, opt => opt.MapFrom(src => src.Categories.Select(c => c.Name).ToList()));
            CreateMap<CreateProductCommand, Product>();
            CreateMap<UpdateProductCommand, Product>();
        }
    }
}
