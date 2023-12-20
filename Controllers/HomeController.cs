using Alena.Models;
using Alena.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alena.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {
            //List<ProductModel> productList = new List<ProductModel>();
            // Cách 1 để Add 1 Object vào 1 List
            //productList.Add(new ProductModel("ao len nu", 119000));
            //productList.Add(new ProductModel("Chân váy nữ", 70000));

            // Cách 2 để Add 1 Object vào 1 List, nhưng trong Model phải chứ Constructor nhận các tham số đầu vào
            //productList.Add(new ProductModel("Áo khoác nữ", 300000));

            //Cách 1 để truyền dữ liệu vào view Controller -> View
            //ViewBag.productList = productList;
            //return View();

            //Cách 2 để truyền dữ liệu vào view Controller -> View

            List<ProductModel> productList = _productService.getAllProduct();
            return View(productList);
        }

        [Route("[controller]/[action]/{id}")]
        public IActionResult ProductDetail(int id)
        {
            ProductModel product = _productService.getProductById(id);
            if (product == null)
            {
                return View("~/Views/Shared/NotFound.cshtml");
            }

            return View(product);
        }
    }
}
