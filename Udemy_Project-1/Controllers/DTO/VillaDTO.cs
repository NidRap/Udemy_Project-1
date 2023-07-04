using System.ComponentModel.DataAnnotations;

namespace Udemy_Project_1.Controllers.DTO
{
    public class VillaDTO
    {
        public int Id
        {
            get; set;
        }
        [Required]
        [MaxLength(30)]
        public String Name
        {
            get; set;
        }
        public int occupancy { get; set; }
        public int sqft {get; set; }
    }
}
