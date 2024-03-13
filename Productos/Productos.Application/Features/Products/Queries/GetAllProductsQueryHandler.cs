using MediatR;
using Productos.Domain.Entities;

namespace Productos.Application.Features.Products.Queries;

public record GetAllProductsQueryHandler : IRequest<ICollection<Product>>;