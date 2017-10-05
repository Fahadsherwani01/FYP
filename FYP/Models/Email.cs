using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP.Models
{
        public partial class Email
        {
            public int Id { get; set; }
            public string To { get; set; }
            public string From { get; set; }
            public string Message { get; set; }
            public string Reply { get; set; }
            public string Date { get; set; }
            public string Read { get; set; }
        }
    
}
