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
    /// <summary>
    /// Profile ACTS as a publically exposed extension of the ApplicationUser class
    /// Profile Holds data that should be publically accessible by other users
    /// </summary>
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Picture { get; set; }
        [Required]
        public string Location { get; set; }
        //Houses the interests of a user such as MOPAR or JDM
        public ICollection<Interest> Interests { get; set; }
        //Houses the cars owned by the users
        public ICollection<Car> Cars { get; set; }
        //Houses the events that the user has rsvped for
        public ICollection<Event> Meets { get; set; }
        //Identifying relationship to where one profile has one user
        public ApplicationUser User { get; set; }
        //Utilized for profile picture implementation, not publically exposed
        [NotMapped]
        public IFormFile Upload { get; set; }

    }
}
