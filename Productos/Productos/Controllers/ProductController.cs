using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Features.Productos.Commands;
using Productos.Application.Features.Productos.Queries;

namespace Productos.Controllers
{
    public class ProductController( IMediator mediator ) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new GetAllProductsQueries());
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductAsync( CreateProductoCommands productoCommands )
        {
            var product = await mediator.Send(productoCommands);
            return Ok(product);
        }
    }
}