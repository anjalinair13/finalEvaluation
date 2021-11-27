using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class Project
    {
        public Project()
        {
            RequestTable = new HashSet<RequestTable>();
        }

        public decimal ProjectId { get; set; }
        public string ProjectName { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<RequestTable> RequestTable { get; set; }
    }
}
