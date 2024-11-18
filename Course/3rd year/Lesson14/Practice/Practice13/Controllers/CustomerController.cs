using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Practice13.Interfaces;
using Practice13.Models;

namespace Practice13.Controllers
{
    [Controller]
    [Route("customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customers;
        public CustomerController(ICustomerManager customers)
        {
            _customers = customers;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddOrder([FromBody] Customer newCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addingCustomer = await _customers.GetCustomerById(newCustomer.Id);
            if (addingCustomer != null)
            {
                return BadRequest("Покупатель с таким Id уже существует");
            }
            return Ok(await _customers.AddCustomer(newCustomer));
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customers.GetCustomers());
        }

        [HttpGet]
        [Route("get/{customerId}")]
        public async Task<IActionResult> GetCustomerById(long customerId)
        {
            var needCustomer = await _customers.GetCustomerById(customerId);
            if (needCustomer != null)
            {
                return Ok(needCustomer);
            }
            return NotFound("Покупателя с таким id не существует");
        }

        [HttpDelete]
        [Route("delete/{customerId}")]
        public async Task<IActionResult> DeleteCustomer(long customerId)
        {
            var deletingCustomer = await _customers.DeleteCustomer(customerId);
            if (deletingCustomer != null)
            {
                return Ok("Покупатель удален");
            }
            return NotFound("Покупателя с таким id не существует");
        }
    }
}
