using Alena.Models;
using Alena.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alena.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index(string collection)
        {
            List<ProductModel> products = new List<ProductModel>();
            switch (collection)
            {
                case "men-collection":
                    ViewBag.title = "Thời trang Nam";
                    products = _productService.getProductByCategory("Thời trang Nam");
                    break;
                case "product":
                    ViewBag.title = "Sản phẩm";
                    products = _productService.getProductByCategory("Quần áo");
                    break;
                case "boy-collection":
                    ViewBag.title = "Bé trai";
                    products = _productService.getProductByCategory("Bé trai");
                    break;
                case "girl-collection":
                    ViewBag.title = "Bé gái";
                    products = _productService.getProductByCategory("Bé gái");
                    break;
            }

            return View(products);
        }
    }
}
