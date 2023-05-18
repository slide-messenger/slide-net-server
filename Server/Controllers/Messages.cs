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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetChats([FromBody] Server.Bodies.GetChatsBody body)
        {
            Console.WriteLine($"Запрос на получение чатов пользователя #{body.UserId}");
            if (!await SQLUsers.Exists(body.UserId))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            var res = await SQLMessages.GetChats(body.UserId);
            return res is null ? 
                StatusCode(StatusCodes.Status500InternalServerError) : Ok(res);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMessages([FromBody] Server.Bodies.GetMessagesBody body)
        {
            Console.WriteLine($"Запрос на получение пользователем {body.UserId} сообщений чата #{body.ChatId}");
            if (!await SQLUsers.Exists(body.UserId))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            if (!await SQLMessages.ChatExists(body.ChatId))
            {
                Console.WriteLine($"Чата #{body.ChatId} не существует!");
                return NotFound();
            }
            if (!await SQLMessages.ReadAll(body.UserId, body.ChatId))
            {
                Console.WriteLine("Не удалось установить статус прочитано сообщений!");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var res = await SQLMessages.GetMessages(body.ChatId);
            return res is null ? 
                StatusCode(StatusCodes.Status500InternalServerError) : Ok(res);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Send([FromBody] Server.Entities.Message body)
        {
            Console.WriteLine("Запрос на отправку сообщения");
            Console.WriteLine(body.ToString());
            if (!await SQLUsers.Exists(body.SenderId))
            {
                Console.WriteLine($"Пользователя #{body.SenderId} не существует!");
                return Unauthorized();
            }
            if (!await SQLMessages.ChatExists(body.ChatId))
            {
                Console.WriteLine($"Чата #{body.ChatId} не существует!");
                return NotFound();
            }
            return await SQLMessages.Send(body) ?
                Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> CheckForNew([FromBody] Server.Bodies.CheckForNewBody body)
        {
            Console.WriteLine($"Запрос на обновление сообщений пользователя #{body.UserId}");
            if (!await SQLUsers.Exists(body.UserId))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            return await SQLMessages.CheckForNew(body.UserId, body.ChatId) ?
                Ok() : NoContent();
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateChat([FromBody] Server.Entities.Chat body)
        {
            Console.WriteLine($"Запрос на создание чата пользователем {body.FirstId}");
            if (!await SQLUsers.Exists(body.FirstId))
            {
                Console.WriteLine($"Пользователя #{body.FirstId} не существует!");
                return Unauthorized();
            }
            if (body.SecondId != 0 && !await SQLUsers.Exists(body.SecondId))
            {
                Console.WriteLine($"Пользователя #{body.SecondId} не существует!");
                return NotFound();
            }
            if (body.FirstId == body.SecondId || 
                await SQLMessages.DialogExists(body.FirstId, body.SecondId))
            {
                Console.WriteLine($"Такой чат уже существует");
                return Conflict();
            }
            int id = await SQLMessages.CreateChat(body);
            return id > 0 ?
               Ok(id) : StatusCode(StatusCodes.Status500InternalServerError);
        }
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> JoinChat([FromBody] Server.Bodies.JoinChatBody body)
        {
            Console.WriteLine($"Запрос на присоединение пользователя {body.UserId} к чату {body.ChatId}");
            if (!await SQLUsers.Exists(body.UserId))
            {
                Console.WriteLine($"Пользователя #{body.UserId} не существует!");
                return Unauthorized();
            }
            if (!await SQLMessages.ChatExists(body.ChatId))
            {
                Console.WriteLine($"Чата #{body.ChatId} не существует!");
                return NotFound();
            }
            var type = await SQLMessages.GetChatType(body.ChatId);
            if (type == Server.Entities.ChatType.DirectChat || 
                type == Server.Entities.ChatType.SavedMessages)
            {
                Console.WriteLine($"Попытка присоединиться к личному чату");
                return UnprocessableEntity();
            }
            if (await SQLMessages.IsUserInChat(body.UserId, body.ChatId))
            {
                Console.WriteLine("Пользователь уже состоит в этом чате");
                return Conflict();
            }
            return await SQLMessages.JoinChat(body.UserId, body.ChatId) ?
                Ok() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
