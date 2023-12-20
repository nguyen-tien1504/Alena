using Alena.Models;

namespace Alena.Services
{
    public interface IProductService
    {
        public List<ProductModel> getAllProduct();
        public ProductModel? getProductById(int id);

        public List<ProductModel> getProductByCategory(string category);

        public void editProduct(ProductModel product);
        public List<CategoryModel> getProductCategories();

        public void addProduct(ProductModel product);

        public void deleteProduct(int id);
    }
}
