using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthMonitor.DataUploader.Models
{
    public class UserAddViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public string HeartRate { get; set; }
        public string GlucoseLevel { get; set; }
        public string CreatineLevel { get; set; }
        public string BloodPressure { get; set; }
        public DateTime Date { get; set; }
    }
}
