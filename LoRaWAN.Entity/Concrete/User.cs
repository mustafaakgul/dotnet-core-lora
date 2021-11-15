using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace LoRaWAN.Entity.Concrete
{
    public class User : IdentityUser<long>
    {
        public User()
        {
            EndNodes = new HashSet<EndNode>();
            Gateways = new HashSet<Gateway>();
        }

        //public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public bool IsChangedPassword { get; set; }
        public bool IsMailConfirm { get; set; }
        public bool IsGSMConfirm { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public virtual ICollection<EndNode> EndNodes { get; set; }
        public virtual ICollection<Gateway> Gateways { get; set; }
    }
}
