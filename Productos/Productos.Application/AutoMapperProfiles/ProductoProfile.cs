using AutoMapper;
using Productos.Application.Features.Productos.Commands;
using Productos.Domain.Entities;

namespace Productos.Application.AutoMapperProfiles;
public class ProductoProfile : Profile
{
    public ProductoProfile()
    {
        CreateMap<CreateProductoCommands, Product>().ReverseMap();
    }
}