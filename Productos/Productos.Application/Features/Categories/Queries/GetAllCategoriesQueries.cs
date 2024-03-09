using MediatR;
using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.Application.Features.Categories.Queries;

public record GetAllCategoriesQueries : IRequest<ICollection<Category>>;