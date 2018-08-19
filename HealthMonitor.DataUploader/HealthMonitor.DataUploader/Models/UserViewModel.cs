using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeartRate { get; set; }
        public string GlucoseLevel { get; set; }
        public string CreatineLevel { get; set; }
        public string BloodPressure { get; set; }
        public DateTime Date { get; set; }
    }
}
