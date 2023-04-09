using City.Application.Neighborhoods.Queries.GetNeighborhoods;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace City.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighborhoodsController : ApiControllerBase
    {
        // GET: api/<NeighborhoodsController>
        [HttpGet]
        public async Task<ActionResult<List<NeighborhoodDto>>> GetNeighborhoods()
        {
            return await Mediator.Send(new GetNeighborhoodsQuery());
        }

        // GET api/<NeighborhoodsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NeighborhoodsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NeighborhoodsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NeighborhoodsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
