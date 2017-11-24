using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAutomationServer.Data.Entities
{
    [Table("HA_Setting")]
    public class SettingEntity : EntityBaseClass
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}