using AutoMapper;
using ConsumingApiSection.Models;
using ConsumingApiSection.Models.DTO;

namespace ConsumingApiSection
{
    public class mappingConfig :Profile
    {
        
        public mappingConfig()
        {
            CreateMap<VillaDTO, VillaDTOCreateTable>().ReverseMap();

            CreateMap<VillaDTO, VillaDTOUpdateTable>().ReverseMap();


            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    } 
}
