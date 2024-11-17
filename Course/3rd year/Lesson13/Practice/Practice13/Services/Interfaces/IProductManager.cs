using Practice13.Services.Models;

namespace Practice13.Services.Interfaces
{
    public interface IProductManager
    {
        public Task<List<Product>> GetProducts();
        public Task<Product> GetProductById(long productId);
        public Task<Product> AddProduct(Product product);
        public Task<Product> DeleteProduct(long productId);
    }
}
