using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HealthMonitor.Infrastructure
{
    public static class HealthTrackerStaticReading
    {
        public static string GetTrackerValue(string name)
        {
            string returndata = String.Empty;
            using (StreamReader sr = new StreamReader("StaticReadings.json"))
            {
                string data = sr.ReadToEnd();
                var jsonData = JsonConvert.DeserializeObject<StaticHealthTrackingObj>(data);
                switch (name)
                {
                    case "BloodSugar":
                        returndata = jsonData.BloodSugar;
                        break;
                    case "BloodPressure":
                        returndata = jsonData.BloodPressure;
                        break;
                    case "Creatine":
                        returndata = jsonData.Creatine;
                        break;
                    default:
                        returndata = jsonData.HeartRate;
                        break;
                }
            }
                return returndata;
        }

        public static string BloodPressure => GetTrackerValue("BloodPressure");
        public static string BloodSugar => GetTrackerValue("BloodSugar");
        public static string HeartRate => GetTrackerValue("HeartRate");
        public static string Creatine => GetTrackerValue("Creatine");
    }


    public class StaticHealthTrackingObj
    {
        public string HeartRate { get; set; }
        public string BloodSugar { get; set; }
        public string BloodPressure { get; set; }
        public string Creatine { get; set; }
    }
}
