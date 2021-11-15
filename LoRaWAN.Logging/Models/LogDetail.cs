using System;
using System.Collections.Generic;
using System.Text;

namespace LoRaWAN.Logging.Models
{
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public IList<LogParameter> Parameters { get; set; }
        public string Message { get; set; }
    }
}
