using System.ComponentModel.DataAnnotations;

namespace ConsumingApiSection.Models.DTO
{
    public class VillaNumberCreateDTO
    {
        [Required]
        public int villaNo { get; set; }
        public string SpclDetails { get; set; }
    }
}
