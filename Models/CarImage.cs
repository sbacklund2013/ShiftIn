using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string Path { get; set; }
        //If the image cant be loaded, what is to be displayed
        [Required]
        public string Alt { get; set; }

        //For image uploading
        [NotMapped]
        public IFormFile Upload { get; set; }

    }
}
