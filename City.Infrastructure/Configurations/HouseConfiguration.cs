using City.Domain.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City.Infrastructure.Configurations
{
	public class HouseConfiguration : IEntityTypeConfiguration<House>
	{
		public void Configure(EntityTypeBuilder<House> builder)
		{
			builder.Property(h => h.Name).HasMaxLength(100).IsRequired();
		}
	}
}
