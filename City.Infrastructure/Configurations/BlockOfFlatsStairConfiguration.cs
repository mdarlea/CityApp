using City.Domain.Entities.Buildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace City.Infrastructure.Configurations
{
	public class BlockOfFlatsStairConfiguration : IEntityTypeConfiguration<BlockOfFlatsStair>
	{
		public void Configure(EntityTypeBuilder<BlockOfFlatsStair> builder)
		{
			builder.Property(b => b.Stair).HasMaxLength(10).IsRequired();
		}
	}
}
