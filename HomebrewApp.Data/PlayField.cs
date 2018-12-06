using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    class PlayField
    {
        public int EnemyId { get; set; }
        public virtual Enemy Enemy { get; set; }
        public int SettingId { get; set; }
        public virtual Setting Setting { get; set; }
    }
}
