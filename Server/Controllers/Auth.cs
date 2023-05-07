using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server;
using Server.Entities;
using Server.SQLServer;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Auth : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SignIn([FromBody] AuthData data)
        {
            Console.WriteLine($"Поступил запрос на авторизацию с данными {data.UserName}:{data.PasswordHash}");
            var user = await SQLUsers.Get(data.UserName);
            if (user == null || user.RemoveState)
            {
                Console.WriteLine("Пользователь не найден!");
                return NotFound();
            }
            else if (data.PasswordHash != user.PasswordHash)
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

    }
}
