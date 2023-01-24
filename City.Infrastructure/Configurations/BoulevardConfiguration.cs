using City.Domain.Entities.NeighborhoodEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City.Infrastructure.Configurations
{
	public class BoulevardConfiguration : IEntityTypeConfiguration<Boulevard>
	{
		public void Configure(EntityTypeBuilder<Boulevard> builder)
		{
			
		}
	}
}
