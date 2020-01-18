using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Underwater.Models;

namespace CodersAcademy.Data.Mapping
{
    public class AquariumMap : IEntityTypeConfiguration<Aquarium>
    {
        public void Configure(EntityTypeBuilder<Aquarium> builder)
        {
            builder.ToTable("Aquarium");

            builder.HasKey(x => x.AquariumId);
            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(150).IsRequired();
            builder.Property(x => x.Address).HasColumnName("Address").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Number).HasColumnName("Number").HasMaxLength(200).IsRequired();
            builder.Property(x => x.Open).HasColumnName("Open").IsRequired();
            builder.HasMany(x => x.Fishes)
                   .WithOne(x => x.Aquarium)
                   .HasForeignKey(x => x.AquariumId);
        }
    }
}
