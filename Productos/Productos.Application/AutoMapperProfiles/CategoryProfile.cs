using AutoMapper;
using Productos.Application.Features.Categories.Commands;
using Productos.Domain.Entities;

namespace Productos.Application.AutoMapperProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
        CreateMap<DeleteCategoryCommand, Category>().ReverseMap();
        CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
    }
}