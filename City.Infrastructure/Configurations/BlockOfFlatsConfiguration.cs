using City.Domain.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City.Infrastructure.Configurations
{
	public class BlockOfFlatsConfiguration : IEntityTypeConfiguration<BlockOfFlats>
	{
		public void Configure(EntityTypeBuilder<BlockOfFlats> builder)
		{
			builder.HasMany(b => b.BlockOfFlatsStairs).WithOne(s => s.BlockOfFlats).IsRequired();

			builder.Property(b => b.BlockNumber).HasMaxLength(10).IsRequired();

			builder.Metadata?
				.FindNavigation(nameof(BlockOfFlats.BlockOfFlatsStairs))?
				.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}
