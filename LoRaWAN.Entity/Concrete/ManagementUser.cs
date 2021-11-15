using System;

namespace LoRaWAN.Entity.Concrete
{
    public class ManagementUser
    {
        public ManagementUser()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long AuthorId { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
}
