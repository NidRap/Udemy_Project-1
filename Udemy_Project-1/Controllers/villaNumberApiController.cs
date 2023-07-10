using Microsoft.AspNetCore.Mvc;
using Udemy_Project_1.Models;
using Udemy_Project_1.Data;
using Microsoft.AspNetCore.JsonPatch;
using Udemy_Project_1.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Udemy_Project_1.Repository.IRepository.IRepository;
using System.Net;
using Udemy_Project_1.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Udemy_Project_1.Controllers
{
    //[Route("api/Controller")]

    [Route("api/VillaNUmberAPI")]
    [ApiController]
    public class villaNumberApiController : ControllerBase
    {
      

        private readonly IVillaNumberRepository _dbRepos;

        private readonly IMapper _mapper;
        protected readonly APIResponse _response;
        //public villaApiController(ApplicationDbContext db , IMapper mapper
        //    )
        public villaNumberApiController(IVillaNumberRepository dbRepos, IMapper mapper
            )
        {
            _dbRepos= dbRepos;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        

        public async Task<ActionResult<APIResponse>> GetVillaNumber()

        
        {
         
            try
            {

                //Repository
                IEnumerable<VillaNumber> villaList = await _dbRepos.GetAll();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaList);

                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMsg = new List<string> { ex.ToString() };
            }
            return _response;

        }
        [HttpGet("id:int", Name = "GetVillaNumber")]
       [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]

        [ProducesResponseType(400)]


        public async Task<ActionResult<APIResponse>> GetVillaIndividual(int id)
        {
            if (id == 0)
            {
                return BadRequest();

            }
        
            var villa = await _dbRepos.Get(u => u.VillaNo == id);

            if (villa == null)
            {
                return NotFound();
            }
            _response.Result = _mapper.Map<VillaNumberDTO>(villa);

            _response.statusCode = HttpStatusCode.OK;

            return Ok(_response);
        }

        [HttpPost]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]

        [ProducesResponseType(500)]


        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaNumberCreateDTO villaDTO)
        {

            try
            {

                if (await _dbRepos.Get(u => u.VillaNo == villaDTO.villaNo) != null)
                {
                    ModelState.AddModelError("Custom error", "Villa already Exists");
                    return BadRequest(ModelState);

                }
                if (villaDTO == null)
                {
                    return BadRequest(villaDTO);
                }
               
                VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);


                await _dbRepos.Create(model);

                _response.Result = _mapper.Map<VillaDTO>(model);

                _response.statusCode = HttpStatusCode.Created;


                return CreatedAtRoute("GetVilla", new { id = model.VillaNo }, _response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMsg
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        public async Task<IActionResult> DeleteVilla(int id)

        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villa = await _dbRepos.Get(u => u.VillaNo == id);

            if (villa == null)
            {
                return NotFound();

            }
            
            await _dbRepos.Remove(villa);

            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "updateVillaNumber")]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaNumberUpdateDTO villaDTO)
        {

            if (villaDTO == null || id != villaDTO.villaNo)
            {
                return BadRequest();
            }
          

          VillaNumber model = _mapper.Map<VillaNumber>(villaDTO);

          
          
            await _dbRepos.Update(model);
            _response.statusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            return Ok();
        }



        //[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]

        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]


        //public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaDTOUpdateTable> patchDto)

        //{
        //    if (patchDto == null || id == 0)
        //    {
        //        return BadRequest();
        //    }

         
        //    var villa = await _dbRepos.Get(u => u.Id == id);

        //    VillaDTOUpdateTable VillaDTO = new()

        //    {
        //        Amenity = villa.Amenity,
        //        Details = villa.Details,
        //        Id = villa.Id,
        //        imgUrl = villa.imgUrl,

        //        occupancy = villa.occupancy,
        //        Rate = villa.Rate,
        //        sqft = villa.sqft

        //    };

        //    if (villa == null)
        //    {
        //        return BadRequest();
        //    }
        //    patchDto.ApplyTo(VillaDTO, ModelState);

        //    Villa model = new Villa()
        //    {
        //        Amenity = VillaDTO.Amenity,
        //        Details = VillaDTO.Details,
        //        Id = VillaDTO.Id,
        //        imgUrl = VillaDTO.imgUrl,

        //        occupancy = VillaDTO.occupancy,
        //        Rate = VillaDTO.Rate,
        //        sqft = VillaDTO.sqft

        //    };

          
        //    await _dbRepos.Update(model);



        //    if (ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);

        //    }
        //    return NoContent();
        //}




    }

}
