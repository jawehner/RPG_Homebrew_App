using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    class Reference
    {
        [Key]
        public int ReferenceId { get; set; }
        public int SettingId { get; set; }
        public virtual Enemy Enemy { get; set; }
        public virtual Setting Setting { get; set; }
    }
}
