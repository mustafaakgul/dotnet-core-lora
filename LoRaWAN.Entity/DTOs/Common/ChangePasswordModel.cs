using System;
using System.Collections.Generic;
using System.Text;

namespace LoRaWAN.Entity.DTOs.Common
{
    public class ChangePasswordModel
    {
        public long UserID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}
