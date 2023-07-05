﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Udemy_Project_1.Controllers.DTO
{
    public class VillaDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public String Name
        {
            get; set;
        }
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }

        public int sqft { get; set; }

        public int occupancy { get; set; }

        public string imgUrl { get; set; }

        public string Amenity { get; set; }

      
    }
}
