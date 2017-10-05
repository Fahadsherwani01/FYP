using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FYP.Models
{
    public class Tbladminmedicationrecord
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Bodypart { get; set; }

        [Required]
        public string Disease { get; set; }

        [Required]
        public string Bloodpresure { get; set; }

        [Required]
        public string Heartbeat { get; set; }

        [Required]
        public string Temprature { get; set; }


        [Required]
        public string Generalsymptoms { get; set; }

        [Required]
        public string Medicine { get; set; }

        [Required]
        public string Dosage { get; set; }

        [Required]
        public string Precautions { get; set; }

        [Required]
        public string Diet { get; set; }
    }
}
