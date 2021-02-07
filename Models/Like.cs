﻿using Shiftin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public ForumPost Post { get; set; }
        public Profile Profile { get; set; }
    }
}
