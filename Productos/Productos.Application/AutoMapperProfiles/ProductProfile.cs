using AutoMapper;
using Productos.Application.Features.Products.Commands;
using Productos.Domain.Entities;

namespace Productos.Application.AutoMapperProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductCommand, Product>().ReverseMap();
        CreateMap<DeleteProductoCommand, Product>().ReverseMap();
        CreateMap<UpdateProductCommand, Product>().ReverseMap();
    }
}