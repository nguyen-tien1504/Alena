using Alena.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Alena.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void addProduct(ProductModel product)
        {
            _dataContext.products.Add(product);
            _dataContext.SaveChanges();
        }

        public void editProduct(ProductModel productToUpdate)
        {
            _dataContext.products.Update(productToUpdate);
            _dataContext.SaveChanges();
        }

        public List<ProductModel> getAllProduct()
        {
            return _dataContext.products.Include("categories").ToList();
        }

        public List<ProductModel> getProductByCategory(string category)
        {
            return _dataContext.products.Include("categories")
                .Where(p => p.categories.categoryName == category).ToList();
        }

        public ProductModel? getProductById(int id)
        {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            ProductModel product = _dataContext.products.Where(p => p.id == id).Include("categories").FirstOrDefault();
            return product;
        }

        public List<CategoryModel> getProductCategories()
        {
            return _dataContext.categories.ToList();
        }
        public void deleteProduct(int id)
        {
            _dataContext.products.Where(p => p.id == id).ExecuteDelete();
            _dataContext.SaveChanges();
        }
    }
}
