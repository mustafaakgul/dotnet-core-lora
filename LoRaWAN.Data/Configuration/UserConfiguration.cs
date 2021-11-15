using System;
using LoRaWAN.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using LoRaWAN.Utilities.Security;

namespace LoRaWAN.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Surname).IsRequired();
            builder.Property(t => t.Phone).IsRequired();
            builder.Property(t => t.Email).IsRequired();
            builder.Property(t => t.Password).IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.RefreshToken).IsRequired();
            builder.Property(t => t.RefreshTokenExpiry).HasMaxLength(255);
            builder.Property(t => t.IsChangedPassword);
            builder.Property(t => t.IsMailConfirm).IsRequired();
            builder.Property(t => t.IsGSMConfirm).IsRequired();
            builder.Property(t => t.IsBlocked).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDelete).IsRequired();
        }
    }
}
