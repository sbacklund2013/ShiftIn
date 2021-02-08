using Shiftin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    /// <summary>
    /// Represents a real life event that users want to invite others too.
    /// Allows for rsvp
    /// </summary>
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        //When the event is occuring
        [Required]
        public DateTime DateTime { get; set; }
        //Who created the event
        public ApplicationUser Creator { get; set; }
        //A lsit of profiles that are attending
        public ICollection<Profile> Attendees { get; set; }
    }
}
