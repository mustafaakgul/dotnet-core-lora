using System;
using LoRaWAN.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using LoRaWAN.Utilities.Security;

namespace LoRaWAN.Data.Configuration
{
    public class GatewayConfiguration : IEntityTypeConfiguration<Gateway>
    {
        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.GatewayName).IsRequired();
            builder.Property(t => t.GatewayEUI).IsRequired();
            builder.Property(t => t.GatewayDescription).IsRequired();
            builder.Property(t => t.GatewayType).IsRequired();
            builder.Property(t => t.Latitude).IsRequired();
            builder.Property(t => t.Longitude).IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.IsBlocked).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDelete).IsRequired();
        }
    }
}