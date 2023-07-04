using Microsoft.AspNetCore.Mvc;
using Udemy_Project_1.Controllers.DTO;
using Udemy_Project_1.Models;
using Udemy_Project_1.Data;

namespace Udemy_Project_1.Controllers
{
    //[Route("api/Controller")]

    [Route("api/VillaAPI")]
    [ApiController]
    public class villaApiController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(villaStore.villaList);
        }
        [HttpGet("id:int", Name = "GetVilla")]
        // undocumented 
        //[ProducesResponseType(200,Type =typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]

        [ProducesResponseType(400)]

        public ActionResult<VillaDTO> GetVillaIndividual(int id)
        {
            if (id == 0)
            {

                return BadRequest();

            }
            var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
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

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO) {
            /*     if(!ModelState.IsValid)
                 {
                     return BadRequest(ModelState);
                 }
            */
            if (villaStore.villaList.FirstOrDefault
                     (u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null) {
                ModelState.AddModelError("Custom error", "Villa already Exists");
                return BadRequest(ModelState);

            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            villaDTO.Id = villaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            villaStore.villaList.Add(villaDTO);

            //   return Ok(villaDTO);

            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
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
            var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();

            }
            villaStore.villaList.Remove(villa);
            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "DeleteVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
 
            if(villaDTO == null || id != villaDTO.Id)
            {
                return BadRequest();
            }
            var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDTO.Name;
            villa.sqft = villaDTO.sqft;
            villa.occupancy=villaDTO.occupancy;
            return NoContent();
        }

    }
}
