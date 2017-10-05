using System;
using System.Collections.Generic;

namespace FYP.Models
{
    public partial class Reports
    {
        public int Id { get; set; }
        public string ReportId { get; set; }
        public string UrineTest { get; set; }
        public string BloodTest { get; set; }
        public string Hivtest { get; set; }
    }
}
