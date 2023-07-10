using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy_Project_1.Models.DTO
{
    public class VillaDTOUpdateTable
    {
        [Required]

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name
        {
            get; set;
        }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]

        public int sqft { get; set; }
        [Required]

        public int occupancy { get; set; }

        public string imgUrl { get; set; }

        public string Amenity { get; set; }


    }
}
