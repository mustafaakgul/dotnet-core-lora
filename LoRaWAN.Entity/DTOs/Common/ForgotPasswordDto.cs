using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoRaWAN.Entity.DTOs.Common
{
    public class ForgotPasswordDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Code { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
