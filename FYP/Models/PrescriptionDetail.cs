using System;
using System.Collections.Generic;

namespace FYP.Models
{
    public partial class PrescriptionDetail
    {
        public int Id { get; set; }
        public string PrescriptionId { get; set; }
        public string _1medicinePerDay { get; set; }
        public string _2medicinePerDay { get; set; }
        public string _3medicinePerDay { get; set; }
    }
}
