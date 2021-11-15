using Newtonsoft.Json;

namespace LoRaWAN.Logging.Extensions
{
    public static class Convert
    {
        public static string Serializing(this object logMessage)
        {
            return logMessage is string ? logMessage.ToString() : JsonConvert.SerializeObject(logMessage, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
