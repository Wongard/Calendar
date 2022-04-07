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
        public string title{ get; set; }
        public string day { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public string place { get; set; }
        public string note { get; set; }
    }
}
