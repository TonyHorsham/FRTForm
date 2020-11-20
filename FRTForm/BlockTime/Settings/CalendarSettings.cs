using System.Collections.Generic;
using FRTForm.BlockTime.Models;

namespace FRTForm.BlockTime.Settings
{
    public class CalendarSettings
    {
        // blockDuration limits may be changed according to block type
        // all in minutes
        public int MinBlockDuration { get; set; }
        public int DefaultBlockDuration { get; set; }
        public int MaxBlockDuration { get; set; }
        public List<Service> Services { get; set; }
    }
}
