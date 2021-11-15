using System;
using System.ComponentModel.DataAnnotations;

namespace LoRaWAN.Entity.Enums
{
    public enum Language
    {
        [Display(Name = "Türkçe")]
        Turkish = 0,    
        [Display(Name = "English")]
        English = 1
    }
}
