using Microsoft.AspNetCore.Http;
using Shiftin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Location { get; set; }
        public ICollection<Interest> Interests { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Event> Meets { get; set; }
        public ApplicationUser User { get; set; }

        [NotMapped]
        public IFormFile Upload { get; set; }

    }
}
