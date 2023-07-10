using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsumingApiSection.Models
{
    public class VillaNumber
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VillaNo { get; set; }

        [ForeignKey("Villa ")]
        public int VillaId
        {
            get; set;
        }
        public Villa Villa
        {
            get; set;
        }
        public String SpclDetails { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; set; }

    }
}
