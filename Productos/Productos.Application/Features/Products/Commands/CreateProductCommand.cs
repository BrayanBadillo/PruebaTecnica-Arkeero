﻿using MediatR;

namespace Productos.Application.Features.Products.Commands;

public record CreateProductCommand( string Name,
                                string Description,
                                decimal Price,
                                int Quantity,
                                int CategoryId ) : IRequest<bool>;