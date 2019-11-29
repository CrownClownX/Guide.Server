using Guide.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.DAL.Configurations
{
    public class MarkerConfiguration : IEntityTypeConfiguration<Marker>
    {
        public void Configure(EntityTypeBuilder<Marker> builder)
        {
            builder.ToTable("markers");

            builder.Property(b => b.Id)
                .HasColumnName("id");

            builder.Property(b => b.Name)
                .HasColumnName("name");

            builder.Property(b => b.Latitude)
                .HasColumnName("lat");

            builder.Property(b => b.Longitude)
                .HasColumnName("lng");

            builder.Property(b => b.UserId)
                .HasColumnName("userId");

            builder.HasOne(m => m.User)
              .WithMany(u => u.Markers)
              .HasForeignKey(m => m.UserId);

            builder.Property(b => b.CategoryId)
                .HasColumnName("categoryId");

            builder.HasOne(m => m.Category)
              .WithMany(u => u.Markers)
              .HasForeignKey(m => m.CategoryId);

        }
    }
}
