using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    /// <summary>
    /// Represents a single image that is linked a car. 
    /// </summary>
    public class CarImage
    {
        [Key]
        public int Id { get; set; }
        //Where is the image located on the server
        [Required]
        public string Path { get; set; }
        //If the image cant be loaded, what is to be displayed
        [Required]
        public string Alt { get; set; }

    }
}
