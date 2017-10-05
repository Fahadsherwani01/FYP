using System;
using System.Collections.Generic;

namespace FYP
{
    public partial class MedicalHistory
    {
        public int Id { get; set; }
        public string MdId { get; set; }
        public string Disease { get; set; }
        public string PrescriptionId { get; set; }
        public string ReportId { get; set; }
        public string Diet { get; set; }
    }
}
