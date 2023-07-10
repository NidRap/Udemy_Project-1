using AutoMapper;
using Udemy_Project_1.Models;
using Udemy_Project_1.Models.DTO;

namespace Udemy_Project_1
{
    public class mappingConfig :Profile
    {
        
        public mappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa, VillaDTOCreateTable>().ReverseMap();

            CreateMap<Villa, VillaDTOUpdateTable>().ReverseMap();
            



			CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
           
            CreateMap<VillaNumber ,VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();


        }
    } 
}
