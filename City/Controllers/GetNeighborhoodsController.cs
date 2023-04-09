using City.Application.Common.Models;
using City.Application.NeighborhoodEntities.Queries.Neighborhoods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace City.Controllers
{
    [Authorize]
    public class GetNeighborhoodsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<NeighborhoodSearchDto>>> GetNeighborhoods([FromQuery] GetNeighborhoodsQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
