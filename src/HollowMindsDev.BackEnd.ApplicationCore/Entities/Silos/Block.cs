﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollowMindsDev.BackEnd.ApplicationCore.Entities.Silos
{
    public class Block : Entity<int>
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}
