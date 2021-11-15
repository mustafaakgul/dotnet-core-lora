namespace LoRaWAN.Utilities.Models
{
    public class PasswordOptions
    {
        public int RequiredLength { get; set; }
        public int RequiredUniqueChars { get; set; }
        public bool RequireDigit { get; set; }
        public bool RequireLowercase { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireUppercase { get; set; }

        public PasswordOptions()
        {
            RequiredLength = default;
            RequiredUniqueChars = default;
            RequireDigit = default;
            RequireLowercase = default;
            RequireNonAlphanumeric = default;
            RequireUppercase = default;
        }
    }
}
