using Microsoft.AspNetCore.Mvc;
using Server.SQLServer;

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messages : Controller
    {
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetChats([FromBody] Server.Entities.GetChatsBody body)
        {
            Console.WriteLine($"Запрос на получение чатов пользователя #{body.UserId}");
            if (!await SQLUsers.Exists(body.UserId.ToString()))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            var result = await SQLMessages.GetChats(body.UserId);
            return Ok(result);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMessages([FromBody] Server.Entities.GetMessagesBody body)
        {
            Console.WriteLine($"Запрос на получение пользователем {body.UserId} сообщений чата #{body.ChatId}");
            if (!await SQLUsers.Exists(body.UserId.ToString()))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            if (!await SQLMessages.ChatExists(body.ChatId))
            {
                Console.WriteLine($"Чата #{body.ChatId} не существует!");
                return NotFound();
            }
            await SQLMessages.ReadAll(body.UserId, body.ChatId);
            return Ok(await SQLMessages.GetMessages(body.UserId, body.ChatId));
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Send([FromBody] Server.Entities.Message body)
        {
            Console.WriteLine("Запрос на отправку сообщения");
            Console.WriteLine(body.ToString());
            if (!await SQLUsers.Exists(body.SenderId.ToString()))
            {
                Console.WriteLine($"Пользователя #{body.SenderId} не существует!");
                return Unauthorized();
            }
            if (!await SQLMessages.ChatExists(body.ChatId) || 
                !await SQLMessages.Send(body))
            {
                Console.WriteLine($"Чата #{body.ChatId} не существует!");
                return NotFound();
            }
            return Ok();
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CheckForNew([FromBody] Server.Entities.CheckForNewBody body)
        {
            Console.WriteLine($"Обновление сообщений пользователя #{body.UserId}");
            if (!await SQLUsers.Exists(body.UserId.ToString()))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            return await SQLMessages.CheckForNew(body.UserId, body.ChatId) ?
                Ok() : NotFound();
        }
    }
}
