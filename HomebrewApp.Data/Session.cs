using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    class Session
    {
        public int SessionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Setting Setting { get; set; }
        public Enemy Enemy { get; set; }
        public string Notes { get; set; }
    }
}
