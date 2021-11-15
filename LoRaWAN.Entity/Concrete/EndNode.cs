using System;
using LoRaWAN.Entity.Enums;

namespace LoRaWAN.Entity.Concrete
{
    public class EndNode
    {
        public EndNode()
        {
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public string EndNodeName { get; set; }
        public string EndNodeDescription { get; set; }
        public string ActivationMethod { get; set; }
        public DeviceTypes DeviceType { get; set; }
        public string Status { get; set; }
        public float LastValue { get; set; }
        public float Rssi { get; set; }
        public float Snr { get; set; }
        public float DevEUI { get; set; }
        public float AppEUI { get; set; }
        public float DeviceAddress { get; set; }
        public float NetworkSessionKey { get; set; }
        public float AppSessionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsBlocked { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public virtual User User { get; set; }
    }
}
