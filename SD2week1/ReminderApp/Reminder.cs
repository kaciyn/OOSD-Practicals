using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderApp
{
    public class Reminder
    {
        public string ReminderMessage { get; set; }
        public int DelaySeconds { get; set; }
        public DateTime TimeEntered { get; set; }
        public bool HasBeenTriggered { get; set; }
    }
}
