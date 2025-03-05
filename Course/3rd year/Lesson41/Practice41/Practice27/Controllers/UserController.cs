using Microsoft.AspNetCore.Mvc;
using Practice27.Dto;
using Practice27.Managers;

namespace Practice27.Controllers
{
    [Controller]
    public class UserController : ControllerBase
    {
        private readonly UserManager _manager;

        public UserController(UserManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetUserByNameAsync(string username)
        {
            var result = await _manager.GetUserByNameAsync(username);
            
            if (result == null)
            {
                return BadRequest("Пользователь не найден");
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateUserAsync(UserDto newUser)
        {
            var result = await _manager.CreateUserAsync(newUser);

            return Ok(result);
        }

        [HttpPut]
        [Route("set")]
        public async Task<IActionResult> ChangeUserDataAsync(int id, UserDto newUser)
        {
            var result = await _manager.ChangeUserDataAsync(id, newUser);

            if (result == null)
            {
                return BadRequest("Пользователь не найден");
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var result = await _manager.DeleteUserById(id);

            if (result == null)
            {
                return BadRequest("Пользователь не найден");
            }

            return Ok(result);
        }

    }
}
