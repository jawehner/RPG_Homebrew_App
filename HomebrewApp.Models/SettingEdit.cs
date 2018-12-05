using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SettingEdit
    {
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int EnemyId { get; set; }
        public ICollection<Enemy> Enemy { get; set; }
    }
}
