using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.Entity
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int BloodSugarRate { get; set; }
        public int BloodPressureRate { get; set; }
        public int HeartBeatRate { get; set; }
        public double CreatineLevel { get; set; }
        public DateTime TrackingDate { get; set; }
    }
}
