using City.Application.Common.Models;
using City.Application.NeighborhoodEntities.Queries.ListAddresses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace City.Controllers
{
    [Authorize]
    public class ListAddressesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<NeighborhoodEntityDto>>> ListAddresses([FromQuery] GetAddressesQuery query)
        {
            return await Mediator.Send(query);
        }
    }
}
