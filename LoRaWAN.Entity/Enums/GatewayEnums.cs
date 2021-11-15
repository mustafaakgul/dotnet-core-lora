using System;
using System.ComponentModel.DataAnnotations;

namespace LoRaWAN.Entity.Enums
{
    public enum GatewayTypes
    {
        [Display(Name = "Indoor")]
        Indoor = 0,
        [Display(Name = "Outdoor")]
        Outdoor = 1
    }
}
