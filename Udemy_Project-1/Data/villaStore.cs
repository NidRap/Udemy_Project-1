using Udemy_Project_1.Models.DTO;

namespace Udemy_Project_1.Data
{
    public static class villaStore
    {

        public static List<VillaDTO> villaList = new List<VillaDTO>
        {
            new VillaDTO { Id = 1, Name = "Nidhi Raparia",sqft = 500,occupancy=1 },
                 new VillaDTO { Id = 2, Name = "Beach View",sqft=200,occupancy=5 },
				 new VillaDTO { Id = 3, Name = "My Beach View",sqft=2300,occupancy=5 }



		};
    
    }
      
}
