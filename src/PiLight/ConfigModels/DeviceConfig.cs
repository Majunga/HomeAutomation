using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAutomationClient.ConfigModels
{
    public class DeviceConfig
    {
        public string Name { get; set; }
        public string DeviceTypeName { get; set; }
        public List<string> Sensors { get; set; }
        public Location Location { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public bool Inside { get; set; }
    }
}
