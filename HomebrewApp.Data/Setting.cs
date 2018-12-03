using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    public class Setting
    {
        [Key]
        public int SettingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public Enemy Enemy{ get; set; }
    }
}
