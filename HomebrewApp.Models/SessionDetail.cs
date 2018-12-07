using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SessionDetail
    {
        [Key]
        public int SessionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SettingId { get; set; }
        public string SettingName { get; set; }
        public string Notes { get; set; }
    }
}
