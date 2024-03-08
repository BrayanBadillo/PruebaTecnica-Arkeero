using MediatR;
using Productos.Domain.Entities;

namespace Productos.Application.Features.Productos.Queries;

public record GetAllProductsQueries : IRequest<ICollection<Product>>;
