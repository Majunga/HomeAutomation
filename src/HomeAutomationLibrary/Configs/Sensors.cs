using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutomationLibrary.Configs
{
    public class SensorSettings
    {
        public List<SensorSetting> SensorSetting { get; set; }
    }
    public class SensorSetting
    {
        public int SensorType { get; set; }
        public int SignalMode { get; set; }
        public int? ReadPin { get; set; }
        public int? WritePin { get; set; }
    }
}
