using Shiftin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    public class ForumPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        public ApplicationUser Author { get; set; }

        public ForumCategory Category { get; set; }
        
        //For Replies
        //0 equals new thread
        //id equals parentd
        public int ParentId { get; set; }

        
    }
}
