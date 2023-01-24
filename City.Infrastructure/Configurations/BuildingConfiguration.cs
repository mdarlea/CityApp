using City.Domain.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City.Infrastructure.Configurations
{
	public class BuildingConfiguration : IEntityTypeConfiguration<Building>
	{
		public void Configure(EntityTypeBuilder<Building> builder)
		{
			builder.UseTptMappingStrategy();
		}
	}
}
