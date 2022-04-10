using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Reminder
    {
        public int ID { get; set; }
        public string title{ get; set; } //NOT NULL
        public string day { get; set; } // NOT NUL,  Default -> Monday
        public int hour { get; set; } //NOT NULL
        public int minute { get; set; } // NOT NULL
        public string place { get; set; } 
        public string note { get; set; } 
    }
}
