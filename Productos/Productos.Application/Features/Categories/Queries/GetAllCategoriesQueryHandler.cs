using MediatR;
using Productos.Domain.Entities;

namespace Productos.Application.Features.Categories.Queries;

public record GetAllCategoriesQueryHandler : IRequest<ICollection<Category>>;