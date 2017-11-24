using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table("HA_Setting")]
    public class SettingEntity : EntityBaseClass
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}