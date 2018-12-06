﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
        public string Notes { get; set; }
    }
}
