using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    class SessionDetail
    {
        public int SessionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Setting> Setting { get; set; }
        public ICollection<Enemy> Enemy { get; set; }
        public string Notes { get; set; }
    }
}
