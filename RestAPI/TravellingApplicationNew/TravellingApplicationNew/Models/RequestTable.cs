using System;
using System.Collections.Generic;

namespace TravellingApplicationNew.Models
{
    public partial class RequestTable
    {
        public decimal RequestId { get; set; }
        public string CauseTravel { get; set; }
        public string Source { get; set; }
        public decimal? Destination { get; set; }
        public string Mode { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal? NoDays { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public decimal? EmpId { get; set; }
        public decimal? ProjectId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Registration Emp { get; set; }
        public virtual Project Project { get; set; }
    }
}
