namespace LoRaWAN.Entity.DTOs.Common.Setting
{
    public class Tokens
    {
        public TokenValidationParameters Mobile { get; set; }
        public TokenValidationParameters Pos { get; set; }

        public Tokens()
        {
            Mobile = default;
            Pos = default;
        }
    }
}
