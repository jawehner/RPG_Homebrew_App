﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class EnemyEdit
    {
        public int EnemyId { get; set; }
        public string Name { get; set; }
        public int KineticAC { get; set; }
        public int EnergyAC { get; set; }
        public int Fortitude { get; set; }
        public int Reflex { get; set; }
        public int Will { get; set; }
        public int HP { get; set; }
        public int Initiative { get; set; }
    }
}
