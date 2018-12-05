using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SettingCreate
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int EnemyId { get; set; }

        public virtual Enemy Enemies { get; set; }
    }
}
