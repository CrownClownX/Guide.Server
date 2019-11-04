using Guide.BLL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Guide.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(b => b.Id)
                .HasColumnName("Id");

            builder.Property(b => b.Name)
                .HasColumnName("Name");

            builder.Property(b => b.Email)
                .HasColumnName("Email");

            builder.Property(b => b.PhoneNumber)
                .HasColumnName("Phone");

            builder.Property(b => b.PasswordHash)
                .HasColumnName("passwordHash");

            builder.Property(b => b.PasswordSalt)
                .HasColumnName("passwordSalt");
        }
    }
}
