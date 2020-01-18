using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Underwater.Models;

namespace CodersAcademy.Data
{
    public class FishMap : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> builder)
        {
            builder.ToTable("Fish");
            builder.HasKey(x => x.FishId);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
            builder.Property(x => x.ScientificName).HasMaxLength(300);
            builder.Property(x => x.CommonName).HasMaxLength(300);
            builder.Property(x => x.ImageName).IsRequired().HasMaxLength(300);
            builder.Property(x => x.PhotoFile).HasMaxLength(300);
            builder.Property(x => x.ImageMimeType).IsRequired();
        }
    }
}
