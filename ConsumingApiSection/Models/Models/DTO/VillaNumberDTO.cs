using System.ComponentModel.DataAnnotations;

namespace ConsumingApiSection.Models.DTO
{
    public class VillaNumberDTO
    {
        [Required]
        public int villaNo { get; set; }
        public string SpclDetails { get; set; }

		public VillaDTO Villa { get; set; }
	}
}
