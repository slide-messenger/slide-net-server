using Microsoft.AspNetCore.Mvc;
using MyMessenger;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer.Controllers
{
    public class UsersAPIRequest
    {
        public string Action { get; set; } = string.Empty;
        public User User { get; set; } = new();

        public UsersAPIRequest(string action, User user)
        {
            Action = action;
            User = user;
        }
        public UsersAPIRequest()
        {
            Action = "";
        }
    }
    [Route("api/Users")]
    [ApiController]
    public class Users : ControllerBase
    {
        // список сообщений
        static readonly Dictionary<int, User> DictOfUsers = new();

        // GET: api/<Auth>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            string output = "Not found";
            try
            {
                User user = DictOfUsers[id];
                user.PasswordHash = "HIDDEN";
                output = JsonConvert.SerializeObject(user);
            }
            catch (KeyNotFoundException) { };
            Console.WriteLine($"<Users> Запрошен пользователь #{id} : {output}");
            return output;
        }

        public User? FindByLogin(string login)
        {
            foreach (KeyValuePair<int, User> entry in DictOfUsers)
            {
                if (entry.Value.UserName == login)
                {
                    return entry.Value;
                }
            }
            return null;
        }
        [HttpPost]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType (StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] UsersAPIRequest data)
        {
            Console.WriteLine("<Users>: Поступил POST-запрос");
            if (data == null)
            {
                Console.WriteLine("<Users>: Данные повреждены");
                return BadRequest();
            }
            switch (data.Action)
            {
                case "signin":
                    User? tmp = FindByLogin(data.User.UserName);
                    if (tmp == null)
                    {
                        Console.WriteLine($"<Users>: Пользователя не существует");
                        return NotFound();
                    }
                    if (tmp.PasswordHash == data.User.PasswordHash)
                    {
                        Console.WriteLine("<Users> Успешная авторизация");
                        Console.WriteLine("<Users>: Данные о пользователе\n" + data.User);
                        return Ok();
                    }
                    else
                    {
                        Console.WriteLine($"<Users>: Неверный пароль");
                        return Unauthorized();
                    }
                case "signup":
                    data.User.Id = DictOfUsers.Count;
                    if (FindByLogin(data.User.UserName) == null)
                    {
                        DictOfUsers.Add(data.User.Id, data.User);
                        Console.WriteLine($"<Users>: Пользователь #{data.User.Id} ({data.User.UserName}) успешно зарегистрирован!");
                        Console.WriteLine("<Users>: Данные о пользователе\n" + data.User);
                        return Ok();
                    }
                    else
                    {
                        Console.WriteLine($"<Users>: Пользователь {data.User.UserName} уже существует");
                        return Unauthorized();
                    }
                default:
                    Console.WriteLine($"<Users>: Неизвестное действие: {data.Action}");
                    return BadRequest();
            }
        }
        // PUT api/<Messenger>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Messenger>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
