using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.SQLServer;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        [HttpGet("{username}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string username)
        {
            Console.WriteLine($"Поступил запрос на получение пользователя {username}");
            var user = await SQLUsers.Get(username);

            if (user != null)
            {
                Console.WriteLine(user);
                user.PasswordHash = "";
                return Ok(user);
            }
            else
            {
                Console.WriteLine("Пользователь не найден!");
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            Console.WriteLine($"Получен запрос на регистрацию");
            Console.WriteLine(user);

            if (await SQLUsers.Exists(user.UserName))
            {
                Console.WriteLine($"Пользователь {user.UserName} уже существует!");
                return Unauthorized();
            }

            if (await SQLUsers.Create(user))
            {
                Console.WriteLine($"Пользователь успешно создан!");
                user.PasswordHash = "";
                return CreatedAtRoute("GetUser", new { username = user.UserName }, user);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Получен запрос на удаление пользователя #{id}");

            if (await SQLUsers.UpdateRemoveState(id, true))
            {
                Console.WriteLine($"Пользователь успешно удален");
                return NoContent();
            }
            else
            {
                Console.WriteLine($"Пользователь не найден!");
                return NotFound();
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] User user)
        {
            Console.WriteLine($"Получен запрос на обновление данных пользователя #{user.UserId}");
            Console.WriteLine(user);

            if (await SQLUsers.UpdateName(user))
            {
                Console.WriteLine("Данные успешно обновлены!");
                return NoContent();
            }

            return NotFound();
        }
    }
}
