namespace LoRaWAN.Entity.DTOs.Common.Setting
{
    public class TokenValidationParameters
    {
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

        public TokenValidationParameters()
        {
            SecurityKey = default;
            Issuer = default;
            Audience = default;
        }
    }
}
