using System;
using System.Globalization;
using System.Resources;
using LoRaWAN.Utilities.Email.Resources;

namespace LoRaWAN.Utilities.Email
{

    public static class SubjectMessage
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("Utilities.Email.Resources.Messages", typeof(Messages).Assembly);
        public static string GetSubject(string subject) => ResourceManager.GetString(subject, CultureInfo.CurrentCulture);
        public static string GetMessage(string message, params string[] parameters) => string.Format(ResourceManager.GetString(message, CultureInfo.CurrentCulture), parameters);
    }
}
