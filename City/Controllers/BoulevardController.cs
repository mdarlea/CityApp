using City.Application.NeighborhoodEntities.Commands.CreateNeighborhoodEntity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace City.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoulevardController : ApiControllerBase
    {
        // GET: api/<BoulevardController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BoulevardController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BoulevardController>
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateBoulevardCommand command)
        {
            return await Mediator.Send(command);
        }

        // PUT api/<BoulevardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BoulevardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
