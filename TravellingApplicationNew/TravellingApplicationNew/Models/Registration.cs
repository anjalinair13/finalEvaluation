using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravellingApplicationNew.Models
{
    public partial class Registration
    {
        public Registration()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public decimal EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public decimal? PhoneNumber { get; set; }
        public decimal? LId { get; set; }

       

        public bool? IsActive { get; set; }

        public virtual Login L { get; set; }
        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
