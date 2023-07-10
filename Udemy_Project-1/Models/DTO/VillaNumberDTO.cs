using System.ComponentModel.DataAnnotations;

namespace Udemy_Project_1.Models.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int villaNo { get; set; }
        public string SpclDetails { get; set; }
    }
}
