using Shiftin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    /// <summary>
    /// Represents a posts a user has made on the forum
    /// </summary>
    public class ForumPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        //Which profile created the post
        public Profile Author { get; set; }
        public int AuthorId { get; set; }
        //To which category does this post belong
        public ForumCategory Category { get; set; }
        
        //used for front end exposure
        [NotMapped]
        public int Likes { get; set; }


        //For Replies
        //0 equals new thread
        //id equals parentd
        public int ParentId { get; set; }

        
    }
}
