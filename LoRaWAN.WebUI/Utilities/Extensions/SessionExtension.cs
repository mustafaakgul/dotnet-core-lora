using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace LoRaWAN.WebUI.Utilities.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key) where T : class, new()
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        public static void RemoveObject(this ISession session, string key)
        {
            session.Remove(key);
        }
    }
}