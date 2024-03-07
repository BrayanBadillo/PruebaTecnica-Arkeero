using Microsoft.AspNetCore.Mvc;
using Productos.Repositories;

namespace Productos.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController( IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var products =  _unitOfWork.Product.GetAllProductsAsync();
            return View();
        }
    }
}