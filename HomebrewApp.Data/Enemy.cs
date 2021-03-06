﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewApp.Data
{
    public class Enemy
    {
        [Key]
        public int EnemyId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "KAC")]
        public int KineticAC { get; set; }

        [Required]
        [Display(Name = "EAC")]
        public int EnergyAC { get; set; }

        [Required]
        public int Fortitude { get; set; }

        [Required]
        public int Reflex { get; set; }

        [Required]
        public int Will { get; set; }

        [Required]
        public int HP { get; set; }

        [Required]
        public int Initiative { get; set; }  
    }
}
