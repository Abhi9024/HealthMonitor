using System;
using System.Collections.Generic;
using System.Text;

namespace HealthMonitor.Entity
{
    public class UserHealthTracker
    {
        public int Id { get; set; }
        public int BloodSugarRate { get; set; }
        public int BloodPressureRate { get; set; }
        public int HeartBeatRate { get; set; }
        public double CreatineLevel { get; set; }
        public DateTime TrackingDate { get; set; }
        //public User User { get; set; }
    }
}
