﻿using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class Tblrole
    {
        public Tblrole()
        {
            Login = new HashSet<Login>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Login> Login { get; set; }
    }
}
