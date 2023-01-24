using City.Domain.Common;
using City.Domain.Entities.NeighborhoodEntities;

namespace City.Domain.Entities.Buildings
{
	public class Building : BaseAuditableEntity
	{
		public NeighborhoodEntity? NeighborhoodEntity { get; set; }
	}
}

