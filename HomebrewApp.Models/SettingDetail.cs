using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SettingDetail
    {
        public int SettingId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int MyProperty { get; set; }
        public int EnemyId { get; set; }
        public string EnemyName { get; set; }
        public virtual ICollection<Enemy> Enemy { get; set; }
    }
}
