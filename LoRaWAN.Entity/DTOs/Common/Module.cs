using System.ComponentModel;

namespace LoRaWAN.Entity.DTOs.Common
{
    public class Module
    {
        public long ID { get; set; }
        [DisplayName("Modül İsimi")]
        public string Name { get; set; }
        [DisplayName("Oluşturma")]
        public bool Create { get; set; }
        [DisplayName("Okuma")]
        public bool Read { get; set; }
        [DisplayName("Düzeleme")]
        public bool Update { get; set; }
        [DisplayName("Silme")]
        public bool Delete { get; set; }

        public Module()
        {
            ID = default;
            Name = default;
            Create = default;
            Read = default;
            Update = default;
            Delete = default;
        }
    }
}
