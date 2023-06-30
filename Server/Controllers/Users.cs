using Microsoft.AspNetCore.Mvc;
using Server.Entities;
using Server.SQLServer;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : Controller
    {
        [HttpGet("[action]/{username}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(string username)
        {
            Console.WriteLine($"Запрос на получение пользователя {username}");
            if (!await SQLUsers.Exists(username))
            {
                Console.WriteLine("Пользователь не найден");
                return NotFound();
            }
            var user = await SQLUsers.Get(username);
            if (user is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine(user);
            return Ok(user);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUp([FromBody] Server.Bodies.SignUpBody body)
        {
            Console.WriteLine("Получен запрос на регистрацию");
            Console.WriteLine(body.User);
            if (await SQLUsers.Exists(body.User.UserName))
            {
                Console.WriteLine($"Пользователь {body.User.UserName} уже существует!");
                return Unauthorized();
            }
            int id = await SQLUsers.Create(body.User, body.PasswordHash);
            if (id <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (await SQLMessages.CreateChat(new Chat(
                id,
                ChatType.SavedMessages,
                id
                )) <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Console.WriteLine("Пользователь успешно создан!");
            return CreatedAtRoute("GetUser", new { username = body.User.UserName }, body.User);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignIn([FromBody] AuthData data)
        {
            Console.WriteLine($"Запрос на авторизацию с данными {data.UserName}:{data.PasswordHash}");
            if (!await SQLUsers.Exists(data.UserName))
            {
                Console.WriteLine("Пользователь не найден!");
                return NotFound();
            }
            var user = await SQLUsers.Get(data.UserName);
            if (user is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var passwordHash = await SQLUsers.GetPasswordHash(user.UserId);
            if (passwordHash is null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            if (user.RemoveState)
            {
                Console.WriteLine("Пользователь не найден!");
                return NotFound();
            }
            else if (data.PasswordHash != passwordHash)
            {
                Console.WriteLine("Неправильный пароль!");
                return Unauthorized();
            }
            else
            {
                Console.WriteLine(user);
                return Ok(user);
            }
        }
        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Получен запрос на удаление пользователя #{id}");

            if (!await SQLUsers.Exists(id))
            {
                Console.WriteLine($"Пользователь не найден!");
                return NotFound();
            }

            if (await SQLUsers.UpdateRemoveState(id, true))
            {
                Console.WriteLine($"Пользователь успешно удален");
                return NoContent();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
