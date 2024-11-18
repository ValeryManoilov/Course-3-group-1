using Microsoft.AspNetCore.Mvc;
using Practice13.Interfaces;
using Practice13.Models;

namespace Practice13.Controllers
{
    [Controller]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _products;
        public ProductController(IProductManager products)
        {
            _products = products;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddProduct([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addingProduct = await _products.GetProductById(newProduct.Id);
            if (addingProduct != null)
            {
                return BadRequest("Продукт с таким Id уже существует");
            }
            return Ok(await _products.AddProduct(newProduct));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _products.GetProducts());
        }

        [HttpGet]
        [Route("get/{productId}")]
        public async Task<IActionResult> GetProductById(long productId)
        {
            var needProduct = await _products.GetProductById(productId);
            if (needProduct != null)
            {
                return Ok(needProduct);
            }
            return NotFound("Продукта с таким id не существует");
        }

        [HttpDelete]
        [Route("delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(long productId)
        {
            var deletingProduct = await _products.DeleteProduct(productId);
            if (deletingProduct != null)
            {
                return Ok("Продукт удален");
            }
            return NotFound("Продукта с таким id не существует");
        }
    }
}
