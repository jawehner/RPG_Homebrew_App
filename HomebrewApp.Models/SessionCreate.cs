using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SessionCreate
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Setting Setting { get; set; }

        [Display(Name = "Setting")]
        public int SettingId { get; set; }
        public string Notes { get; set; }
    }
}
