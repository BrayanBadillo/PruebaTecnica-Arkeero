using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Features.Categories.Queries;
using Productos.Application.Features.Productos.Commands;
using Productos.Domain.Entities;

namespace Productos.Controllers
{
    public class CategoryController( IMediator mediator ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new GetAllCategoriesQueries());
            return View( result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoryAsync( CreateProductoCommands productoCommands )
        {
            var product = await mediator.Send(productoCommands);
            return Ok(product);
        }
    }
}
