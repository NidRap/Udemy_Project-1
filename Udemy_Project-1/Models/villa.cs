using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy_Project_1.Models
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get; set;
        }
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public double Rate { get; set; }

        public int sqft { get; set; }

        public int occupancy { get; set; }

        public string imgUrl { get; set; }

        public string Amenity { get; set; }

        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

    }
}
