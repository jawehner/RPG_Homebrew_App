using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomebrewApp.Models
{
    public class EnemyListItem
    {
        public int EnemyId { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
