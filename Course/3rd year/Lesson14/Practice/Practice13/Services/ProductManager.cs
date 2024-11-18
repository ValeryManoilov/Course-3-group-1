using Microsoft.EntityFrameworkCore;
using Practice13.Context;
using Practice13.Interfaces;
using Practice13.Models;

namespace Practice13.Services
{
    public class ProductManager : IProductManager
    {
        private readonly DeliveryAppContext _data;
        public ProductManager(DeliveryAppContext data)
        {
            _data = data;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _data.Products.Include(p => p.OrderProducts).ToListAsync();
        }

        public async Task<Product> GetProductById(long productId)
        {
            var product = await _data.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return product;
        }

        public async Task<Product> AddProduct(Product newProduct)
        {
            var addingProduct = await GetProductById(newProduct.Id);
            if (addingProduct == null)
            {
                await _data.Products.AddAsync(newProduct);
                _data.SaveChanges();
            }
            return newProduct;
        }

        public async Task<Product> DeleteProduct(long productId)
        {
            var deletingProduct = await GetProductById(productId);
            if (deletingProduct != null)
            {
                _data.Remove(deletingProduct);
                _data.SaveChanges();
            }
            return deletingProduct;
        }
    }
}
