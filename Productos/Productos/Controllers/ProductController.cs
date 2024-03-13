using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Features.Categories.Queries;
using Productos.Application.Features.Productos.Queries;
using Productos.Application.Features.Products.Commands;

namespace Productos.Controllers
{
    public class ProductController( IMediator mediator ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo para Crear un Producto
        /// </summary>
        /// <param name="productCommands">Modelo del comando Create Product Command</param>
        /// <returns>Un Status Code con un objeto que es la respuesta de la transacion y un mensaje</returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct( [FromBody] CreateProductCommand productCommands )
        {
            try
            {
                var result = await mediator.Send(productCommands);
                if ( result )
                    return StatusCode(StatusCodes.Status200OK, new { Value = result, msg = "OK" });
                return StatusCode(StatusCodes.Status400BadRequest, new { Value = result, msg = "OK" });
            }
            catch ( Exception e )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Value = e, msg = $"{e.Message}" });
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener todos los productos 
        /// </summary>
        /// <returns>Un Status Code con un objeto que es una lista de productos y un mensaje</returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var lstProducts = await mediator.Send(new GetAllProductsQueryHandler());
                return StatusCode(StatusCodes.Status200OK, new { Value = lstProducts.OrderByDescending(x => x.Id), msg = "OK" });
            }
            catch ( Exception e )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Value = e, msg = $"{e.Message}" });
                throw;
            }
        }

        /// <summary>
        /// Metodo para Actualizar un Producto
        /// </summary>
        /// <param name="ProductCommands">Modelo del comando Update Product Command</param>
        /// <returns>Un Status Code con un objeto que es la respuesta de la transacion y un mensaje</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProduct( [FromBody] UpdateProductCommand ProductCommands )
        {
            var result = await mediator.Send(ProductCommands);

            if ( result )
                return StatusCode(StatusCodes.Status200OK, new { Value = result, msg = "OK" });
            return StatusCode(StatusCodes.Status500InternalServerError, new { Value = result, msg = "ERROR" });
        }

        /// <summary>
        /// Metodo para Eliminar un Producto
        /// </summary>
        /// <param name="ProductCommands">Modelo del comando Delete Product Command</param>
        /// <returns>Un Status Code con un objeto que es la respuesta de la transacion y un mensaje</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct( DeleteProductoCommand ProductCommands )
        {
            try
            {
                var result = await mediator.Send(ProductCommands);

                if ( result )
                    return StatusCode(StatusCodes.Status200OK, new { Value = result, msg = "OK" });
                return StatusCode(StatusCodes.Status400BadRequest, new { Value = result, msg = "ERROR" });
            }
            catch ( Exception e )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Value = e, msg = $"{e.Message}" });
                throw;
            }
        }
    }
}