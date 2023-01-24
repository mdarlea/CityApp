using City.Application.Common.Models;
using City.Application.NeighborhoodEntities.Queries.SearchAddress;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace City.Controllers
{
    [Authorize]
	public class SearchAddressController : ApiControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<PaginatedList<BlockOfFlatsAddressDto>>> SearchAddress([FromQuery] SearchAddressQuery query)
		{
			return await Mediator.Send(query);
		}
    }
}
