using City.Domain.Entities.NeighborhoodEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace City.Infrastructure.Configurations
{    
	public class NeighborhoodEntityConfiguration : IEntityTypeConfiguration<NeighborhoodEntity>
	{
        private const string discriminator = nameof(NeighborhoodEntity.Type);

        public void Configure(EntityTypeBuilder<NeighborhoodEntity> builder)
		{

			builder.UseTphMappingStrategy();
            builder.HasDiscriminator<NeighborhoodEntityType>(discriminator)
                .HasValue<Boulevard>(NeighborhoodEntityType.Boulevard)
                .HasValue<Market>(NeighborhoodEntityType.Market)
                .HasValue<Street>(NeighborhoodEntityType.Street);
            builder.Property(discriminator)
                .IsUnicode(false)
                .HasMaxLength(50);
            builder.HasIndex(discriminator);
            builder.HasIndex(discriminator, nameof(NeighborhoodEntity.PostalCode), nameof(NeighborhoodEntity.Id), nameof(NeighborhoodEntity.Name))
                .IsUnique();

            builder.Property(discriminator)
                .HasConversion(new EnumToStringConverter<NeighborhoodEntityType>());

            builder.Ignore(b => b.BlockOfFlats);
			builder.Ignore(b => b.Houses);

			builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
			builder.Property(b => b.PostalCode).HasMaxLength(50).IsRequired();
			builder.HasOne(b => b.Neighborhood).WithMany(n => n.NeighborhoodEntities).IsRequired();

			builder.HasMany(nt => nt.Buildings).WithOne(b => b.NeighborhoodEntity).IsRequired();

			builder.Metadata?
					.FindNavigation(nameof(NeighborhoodEntity.Buildings))?
					.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}
