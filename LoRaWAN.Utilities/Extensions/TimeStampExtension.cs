using System;
using System.Collections.Generic;
using System.Text;

namespace LoRaWAN.Utilities.Extensions
{
    public static class TimeStampExtension
    {
        public static double ToTimeStamp(this DateTime dateTime)
        {
            return dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public static DateTime ToDateTime(this double timeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timeStamp);
        }
    }
}
