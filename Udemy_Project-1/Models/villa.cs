namespace Udemy_Project_1.Models
{
    public class Villa
    {
        public int Id
        {
            get; set;
        }
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
