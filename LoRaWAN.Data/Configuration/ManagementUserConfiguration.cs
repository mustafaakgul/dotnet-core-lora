using System;
using LoRaWAN.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using LoRaWAN.Utilities.Security;

namespace LoRaWAN.Data.Configuration
{
    public class ManagementUserConfiguration : IEntityTypeConfiguration<ManagementUser>
    {
        public void Configure(EntityTypeBuilder<ManagementUser> builder)
        {
            builder.HasKey(t => t.Id);

        }
    }
}
