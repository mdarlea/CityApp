using City.Application.Common.Interfaces;
using System.Security.Claims;

namespace City.Services
{
	public class CurrentUserService : ICurrentUserService
	{
		private readonly IHttpContextAccessor httpContextAccessor;

		public CurrentUserService(IHttpContextAccessor httpContextAccessor)
		{
			this.httpContextAccessor = httpContextAccessor;
		}

		public string? UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
