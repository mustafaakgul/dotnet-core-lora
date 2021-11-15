using System.Collections.Generic;

namespace LoRaWAN.Entity.DTOs.Common.Setting
{
    public class MWSettings
    {
        public MailServer MailServer { get; set; }
        public Tokens Tokens { get; set; }
        public QR QR { get; set; }
        public List<string> Whitelist { get; set; }
        public Distance Distance { get; set; }
        public ForgotPassword ForgotPassword { get; set; }
    }
}
