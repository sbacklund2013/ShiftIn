using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShiftIn.Models
{
    /// <summary>
    /// Represents a car that a user owns. Contains all information to identity the car
    /// Has collection of carimages to house pictures of the vehicle
    /// </summary>
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Model { get; set; }
        public string Description { get; set; }

        public Profile Profile { get; set; }
        public int ProfileId { get; set; }
        /// <summary>
        /// Used to allow a car to have many images. One to many
        /// </summary>
        public ICollection<CarImage> CarImages { get; set; }

        //This should be in ViewModel
        [NotMapped]
        public int NumberOfCarImages
        {
            get => CarImages.Count;
        }
        public Car()
        {
            CarImages = new List<CarImage>();
        }

    }
}
