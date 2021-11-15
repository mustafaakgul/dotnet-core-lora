using System;
using LoRaWAN.Entity.Enums;

namespace LoRaWAN.Entity.Concrete
{
    public class Gateway
    {
        public Gateway()
        {
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string GatewayName { get; set; }
        public string GatewayEUI { get; set; }
        public string GatewayDescription { get; set; }
        public GatewayTypes GatewayType { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public virtual User User { get; set; }

    }
}
