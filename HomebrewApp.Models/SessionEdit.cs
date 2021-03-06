﻿using HomebrewApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Models
{
    public class SessionEdit
    {
        [Key]
        public int SessionId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int SettingId { get; set; }
        public ICollection<Setting> Settings { get; set; }
        public string Notes { get; set; }
    }
}
