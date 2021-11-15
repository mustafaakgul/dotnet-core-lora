using System;
using System.ComponentModel.DataAnnotations;

namespace LoRaWAN.Entity.Enums
{
    public enum DeviceTypes
    {
        [Display(Name = "Indoor")]
        ABP = 0,
        [Display(Name = "Outdoor")]
        OTAA = 1
    }
}
