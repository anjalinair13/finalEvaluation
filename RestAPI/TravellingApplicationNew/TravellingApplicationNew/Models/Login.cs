using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class Login
    {
        public Login()
        {
            Registration = new HashSet<Registration>();
        }

        public decimal LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual Tblrole Role { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
    }
}
