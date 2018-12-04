using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SessionListItem
    {
        public int SessionId { get; set; }
        public string Name { get; set; }

        [Display(Name="Date of session")]
        public DateTime Date { get; set; }
        public ICollection<Setting> Setting { get; set; }
        public ICollection<Enemy> Enemy { get; set; }
        public string Notes { get; set; }

    }
}
