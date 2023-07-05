using AutoMapper;
using Udemy_Project_1.Controllers.DTO;
using Udemy_Project_1.Models;

namespace Udemy_Project_1
{
    public class mappingConfig :Profile
    {
        
        public mappingConfig()
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            CreateMap<Villa ,VillaDTOCreateTable>().ReverseMap();

            CreateMap<Villa, VillaDTOUpdateTable>().ReverseMap();


        }
    } 
}
