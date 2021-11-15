using System.Collections.Generic;

namespace LoRaWAN.Entity.DTOs.Common.Setting
{
    public class MailServer
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public List<Mail> Mails { get; set; }
    }
}
