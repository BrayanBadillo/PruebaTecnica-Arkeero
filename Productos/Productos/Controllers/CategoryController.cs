using MediatR;
using Microsoft.AspNetCore.Mvc;
using Productos.Application.Features.Categories.Commands;
using Productos.Application.Features.Categories.Queries;

namespace Productos.Controllers
{
    public class CategoryController( IMediator mediator ) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo para crear categorias
        /// </summary>
        /// <param name="CategoryCommand">Modelo del comando Create Category Command</param>
        /// <returns>Status Code con un objeto que es la respuesta de la transacciony un mensaje</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory( [FromBody] CreateCategoryCommand CategoryCommand )
        {
            try
            {
                var result = await mediator.Send(CategoryCommand);
                if ( result )
                    return StatusCode(StatusCodes.Status200OK, new { Value = result, msg = "OK" });
                return StatusCode(StatusCodes.Status400BadRequest, new { Value = result, msg = "OK" });
            }
            catch ( Exception e )
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { Value = e, msg = $"{e.Message}" });
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener todoas las categorias
        /// </summary>
        /// <returns>Status Code con un objeto que es una lista de categorias y un mensaje</returns>
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var lstCategories = await mediator.Send(new GetAllCategoriesQueryHandler());
                return StatusCode(StatusCodes.Status200OK, new { Value = lstCategories, msg = "OK" });
            }
            catch ( Exception e )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Value = e, msg = $"{e.Message}" });
                throw;
            }
        }

        /// <summary>
        /// Metodo para actualizar una categoria
        /// </summary>
        /// <param name="CategoryCommand">Modelo del comando Update Category Command</param>
        /// <returns>Status Code con un objeto que es la respuesta de la transacciony un mensaje</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateCategory( [FromBody] UpdateCategoryCommand CategoryCommand )
        {
            try
            {
                var result = await mediator.Send(CategoryCommand);
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
        /// 
        /// </summary>
        /// <param name="categoryCommand">Modelo del comando Category Command</param>
        /// <returns>Status Code con un objeto que es la respuesta de la transacciony un mensaje</returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory( DeleteCategoryCommand categoryCommand )
        {
            try
            {
                var result = await mediator.Send(categoryCommand);
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
    }
}