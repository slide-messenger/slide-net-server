using Microsoft.AspNetCore.Mvc;
using MyMessenger;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messages : ControllerBase
    {
        // список сообщений
        static readonly List<Message> ListOfMessages = new();

        // GET: api/<Messenger>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // получение сообщений
        // GET api/<Messenger>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string output = "Not found";
            if (id >= 0 && id < ListOfMessages.Count)
            {
                output = JsonConvert.SerializeObject(ListOfMessages[id]);
            }
            Console.WriteLine($"<Messages> Запрошено сообщение #{id} : {output}");
            return output;
        }

        // отправка сообщений
        // POST api/<Messenger>
        [HttpPost]
        public IActionResult Post([FromBody] Message msg)
        {
            if (msg == null)
            {
                return BadRequest();
            }
            ListOfMessages.Add(msg);
            Console.WriteLine($"<Messages> Всего сообщений {ListOfMessages.Count} Посланное сообщение {msg}");
            return Ok();
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
