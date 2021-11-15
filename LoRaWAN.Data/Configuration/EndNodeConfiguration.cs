using System;
using LoRaWAN.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;
using LoRaWAN.Utilities.Security;

namespace LoRaWAN.Data.Configuration
{
    public class EndNodeConfiguration : IEntityTypeConfiguration<EndNode>
    {
        public void Configure(EntityTypeBuilder<EndNode> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.EndNodeName).IsRequired();
            builder.Property(t => t.EndNodeDescription).IsRequired();
            builder.Property(t => t.ActivationMethod).IsRequired();
            builder.Property(t => t.DeviceType).IsRequired();
            builder.Property(t => t.Status).IsRequired();
            builder.Property(t => t.LastValue).IsRequired();
            builder.Property(t => t.Rssi).IsRequired();
            builder.Property(t => t.Snr).IsRequired();
            builder.Property(t => t.DevEUI).HasMaxLength(255);
            builder.Property(t => t.AppEUI);
            builder.Property(t => t.DeviceAddress).IsRequired();
            builder.Property(t => t.NetworkSessionKey).IsRequired();
            builder.Property(t => t.AppSessionKey).IsRequired();
            builder.Property(t => t.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.UpdatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(t => t.IsBlocked).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();
            builder.Property(t => t.IsDelete).IsRequired();
        }
    }
}
