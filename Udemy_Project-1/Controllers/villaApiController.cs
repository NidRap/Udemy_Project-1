using Microsoft.AspNetCore.Mvc;
using Udemy_Project_1.Controllers.DTO;
using Udemy_Project_1.Models;
using Udemy_Project_1.Data;
using Microsoft.AspNetCore.JsonPatch;
using Udemy_Project_1.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Udemy_Project_1.Controllers
{
    //[Route("api/Controller")]

    [Route("api/VillaAPI")]
    [ApiController]
    public class villaApiController : ControllerBase
    {
        //Dependency Injection
        // predefined Logger
        //Read only means constant
        //private readonly ILogger<villaApiController> _logger;

        //    public villaApiController(ILogger<villaApiController> logger) 
        //{
        //    _logger = logger;
        //}

        // custom Logger
        //private readonly Ilogging _logger;

        //public villaApiController(Ilogging logger)
        //{
        //    _logger = logger;
        //}


        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public villaApiController(ApplicationDbContext db , IMapper mapper
            )
        {
            _db = db;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>>GetVillas()

       // public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //  _logger.Log("Getting All villas","");

            // _logger.LogInformation("Getting All villas");
            // return Ok(villaStore.villaList);


            //  return Ok(_db.Villas1.ToList());
           

            return Ok(await _db.Villas1.ToListAsync());

        }
        [HttpGet("id:int", Name = "GetVilla")]
        // undocumented 
        //[ProducesResponseType(200,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]

        [ProducesResponseType(400)]


        public async Task< ActionResult<VillaDTO>> GetVillaIndividual(int id)
        {
            if (id == 0)
            {
              //  _logger.Log("Getting All villas Error with Id " +id,"error");
                return BadRequest();

            }
            // var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);

            //  var villa = _db.Villas1.FirstOrDefault(u => u.Id == id);

            var villa =await  _db.Villas1.FirstOrDefaultAsync(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
        /*
          public IEnumerable<VillaDTO> GetVillas()
          {
              return villaStore.villaList;
          }
          [HttpGet("id:int")]
          public VillaDTO GetVillaIndividual(int id=1)
          {
              return villaStore.villaList.FirstOrDefault(u=>u.Id ==id);
          }

              public IEnumerable<VillaDTO> GetVillas()
               {
                   return new List<VillaDTO>() {
                   new VillaDTO{ Id =1 , Name ="Nidhi Raparia" },
                   new VillaDTO { Id = 2, Name = "Beach View" }

               };
               }

                public IEnumerable<Villa> GetVillas()
               {
                 return new List<Villa>() {
               new Villa{ Id =1 , Name ="Pool View" },
               new Villa { Id = 2, Name = "Beach View" }

               };
          */

        [HttpPost]
        // undocumented 
        //[ProducesResponseType(200,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]

        [ProducesResponseType(500)]

        //  public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO) {

        // seperate create DTO
         public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTOCreateTable villaDTO) {




        /*     if(!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }
            */
        // if (villaStore.villaList.FirstOrDefault
        //        (u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null) {

       

            if (_db.Villas1.FirstOrDefault
                    (u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom error", "Villa already Exists");
                return BadRequest(ModelState);

            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            //if (villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}


            //villaDTO.Id = villaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
           
            Villa model = _mapper.Map<Villa>(villaDTO);
           // above is equal tp below
           // Villa model = new()
           // { 
           // Name = villaDTO.Name,
           // Amenity = villaDTO.Amenity,
           // Details = villaDTO.Details,
           //// Id = villaDTO.Id,
           // imgUrl = villaDTO.imgUrl,
          
           // occupancy = villaDTO.occupancy,
           // Rate = villaDTO.Rate,
           // sqft = villaDTO.sqft

           // };

            _db.Villas1.Add(model);
            _db.SaveChanges();
            
         //   villaStore.villaList.Add(villaDTO);

            //   return Ok(villaDTO);

         //   return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);


        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public IActionResult DeleteVilla(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }
            //    var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
               var villa = _db.Villas1.FirstOrDefault(u => u.Id == id);

            if (villa == null)
            {
                return NotFound();

            }
         //   villaStore.villaList.Remove(villa);

            _db.Villas1.Remove(villa);
            _db.SaveChanges();
            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTOUpdateTable villaDTO)
        {
 
            if(villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            //var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
            //villa.Name = villaDTO.Name;
            //villa.sqft = villaDTO.sqft;
            //villa.occupancy=villaDTO.occupancy;




            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                imgUrl = villaDTO.imgUrl,
                
                occupancy = villaDTO.occupancy,
                Rate = villaDTO.Rate,
                sqft = villaDTO.sqft

            };

            _db.Villas1.Update(model);
            _db.SaveChanges();

            return NoContent();
        }



        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        

      // public IActionResult UpdatePartialVilla(int id , JsonPatchDocument<VillaDTO>patchDto)
       public IActionResult UpdatePartialVilla(int id , JsonPatchDocument<VillaDTOUpdateTable>patchDto)

        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }

           // var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
            var villa = _db.Villas1.FirstOrDefault(u => u.Id == id);

            VillaDTOUpdateTable VillaDTO = new()
            //VillaDTO VillaDTO = new()

            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                imgUrl = villa.imgUrl,
             
                occupancy = villa.occupancy,
                Rate = villa.Rate,
                sqft = villa.sqft

            };

            if (villa == null)
            {
                return BadRequest();
            }
            //   patchDto.ApplyTo(villa, ModelState);
            patchDto.ApplyTo(VillaDTO,ModelState);

            Villa model = new Villa()
            {
                Amenity = VillaDTO.Amenity,
                Details = VillaDTO.Details,
                Id = VillaDTO.Id,
                imgUrl = VillaDTO.imgUrl,
               
                occupancy = VillaDTO.occupancy,
                Rate = VillaDTO.Rate,
                sqft = VillaDTO.sqft

            };

            _db.Villas1.Update(model);
            _db.SaveChanges();

            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return NoContent();
        }




    }

}
