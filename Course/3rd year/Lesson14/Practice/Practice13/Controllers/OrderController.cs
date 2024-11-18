using Microsoft.AspNetCore.Mvc;
using Practice13.Interfaces;
using Practice13.Models;

namespace Practice13.Controllers
{
    [Controller]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orders;
        public OrderController(IOrderManager orders)
        {
            _orders = orders;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddOrder([FromBody] Order newOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addingOrder = await _orders.GetOrderById(newOrder.Id);
            if (addingOrder != null)
            {
                return BadRequest("Заказ с таким Id уже существует");
            }
            return Ok(await _orders.AddOrder(newOrder));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orders.GetOrders());
        }

        [HttpGet]
        [Route("get/{orderId}")]
        public async Task<IActionResult> GetOrderById(long orderId)
        {
            var needOrder = await _orders.GetOrderById(orderId);
            if (needOrder != null)
            {
                return Ok(needOrder);
            }
            return NotFound("Заказа с таким id не существует");
        }

        [HttpDelete]
        [Route("delete/{orderId}")]
        public async Task<IActionResult> DeleteOrder(long orderId)
        {
            var deletingOrder = await _orders.DeleteOrder(orderId);
            if (deletingOrder != null)
            {
                return Ok("Заказ удален");
            }
            return NotFound("Заказа с таким id не существует");
        }
    }
}
