using City.Domain.Entities;
using City.Domain.Entities.Buildings;
using City.Domain.Entities.NeighborhoodEntities;
using Microsoft.EntityFrameworkCore;

namespace City.Application.Common.Interfaces
{
	public interface ICityContext
	{
		public DbSet<Neighborhood> Neighborhoods { get; set; }
		public DbSet<NeighborhoodEntity> NeighborhoodEntities { get; set; }
		public DbSet<Building> Buildings { get; set; }
		public DbSet<BlockOfFlatsStair> BlockOfFlatsStairs { get; set; }
		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
