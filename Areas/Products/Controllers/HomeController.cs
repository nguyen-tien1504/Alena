using Alena.Models;
using Alena.Services;
using Microsoft.AspNetCore.Mvc;

namespace Alena.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IFirestoreService _firestoreService;
        public HomeController(IProductService productService, IFirestoreService firestoreService)
        {
            this._productService = productService;
            this._firestoreService = firestoreService;
        }
        public IActionResult Index()
        {
            List<ProductModel> productList = _productService.getAllProduct();
            ViewBag.categories = _productService.getProductCategories();
            return View(productList);
        }

        [HttpPost]
        public IActionResult EditProduct([Bind(include:["id", "productName", "categoryId", "productCurrentPrice",
            "productOldPrice", "isSoldOut", "productThumbnail", "description"])] ProductModel productRequest)
        {
            _productService.editProduct(productRequest);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductModel productRequest, IFormCollection formRequest)
        {
            IFormFile productImg = formRequest.Files["productImg"];
            var productUri = await _firestoreService.UploadFile(productImg.FileName, productImg);

            productRequest.productThumbnail = productUri;
            _productService.addProduct(productRequest);
            return RedirectToAction("Index");
        }

        [Route("Area/[Area]/[controller]/[action]/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.deleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
