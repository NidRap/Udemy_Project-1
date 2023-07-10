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
using Microsoft.AspNetCore.Authorization;

namespace Udemy_Project_1.Controllers
{
	//[Route("api/Controller")]

	[Route("api/VillaAPI")]
	
	[ApiController]
	public class villaApiController : ControllerBase
	{
		
        private readonly ILogger<villaApiController> _logger;

		public villaApiController(ILogger<villaApiController> logger)
		{
			_logger = logger;
		}


		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		{
			_logger.LogInformation("Getting all villas");
			return Ok(villaStore.villaList);



			//new VillaDTO{Id=1,Name="Pool View" },
			//new VillaDTO{Id=2,Name="Beach View" }		

		}


		//[HttpGet("{id:int}")]
		[HttpGet("{id:int}", Name = "GetVilla")]
		[Authorize(Roles = "admin")]

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public ActionResult<VillaDTO> GetVilla(int id)
		{
			if (id == 0)
			{
				_logger.LogError("Get Villa Error with Id" + id);
				return BadRequest();
			}

			var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
			if (villa == null)
			{
				return NotFound();
			}

			return Ok(villa);
		}

		[HttpPost]
		

		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
		{
			if (villaDTO == null)
			{
				return BadRequest(villaDTO);
			}
			//if (villaDTO.Id > 0)
			//{
			//	return StatusCode(StatusCodes.Status500InternalServerError);
			//}
			villaDTO.Id = villaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
			villaStore.villaList.Add(villaDTO);


			//return Ok(villaDTO);

			return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
		}
		[Authorize(Roles = "CUSTOM")]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
		[HttpPut("{id:int}", Name = "UpdateVilla")]

		public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
		{
			if (villaDTO == null || id != villaDTO.Id)
			{
				return BadRequest();
			}
			var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
			villa.Name = villaDTO.Name;
			villa.sqft = villaDTO.sqft;
			villa.occupancy = villaDTO.occupancy;

			return NoContent();

		}
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]

		public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
		{
			if (patchDTO == null || id == 0)
			{
				return BadRequest();
			}
			var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
			if (villa == null)
			{
				return BadRequest();
			}
			patchDTO.ApplyTo(villa, ModelState);
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			return NoContent();
		}

	}
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


		//private readonly ApplicationDbContext _db;

		//private readonly IVillaRepository _dbRepos;

		//private readonly IMapper _mapper;
		//protected readonly APIResponse _response;
		////public villaApiController(ApplicationDbContext db , IMapper mapper
		////    )
		//public villaApiController(IVillaRepository dbRepos, IMapper mapper
		//    )
		//{
		//    _dbRepos= dbRepos;
		//    _mapper = mapper;
		//    this._response = new();
		//}

		//[HttpGet]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//// public async Task<ActionResult<IEnumerable<VillaDTO>>>GetVillas()

		//public async Task<ActionResult<APIResponse>> GetVillas()

		//// public ActionResult<IEnumerable<VillaDTO>> GetVillas()
		//{
		//    //  _logger.Log("Getting All villas","");

		//    // _logger.LogInformation("Getting All villas");
		//    // return Ok(villaStore.villaList);


		//    //  return Ok(_db.Villas1.ToList());
		//    try
		//    {

		//        //Repository
		//        IEnumerable<Villa> villaList = await _dbRepos.GetAll();
		//        _response.Result = _mapper.Map<List<VillaDTO>>(villaList);
		//        //return Ok(_mapper.Map<List<VillaDTO>>(villaList));

		//        _response.statusCode = HttpStatusCode.OK;

		//        return Ok(_response);

		//        // return Ok(await _db.Villas1.ToListAsync());
		//    }
		//    catch (Exception ex)
		//    {
		//        _response.IsSuccess = false;
		//        _response.ErrorsMsg = new List<string> { ex.ToString() };
		//    }
		//    return _response;

		//}
		//[HttpGet("{id:int}", Name = "GetVilla")]
		//// undocumented 
		////[ProducesResponseType(200,Type =typeof(VillaDTO))]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(404)]

		//[ProducesResponseType(400)]


		//public async Task<ActionResult<APIResponse>> GetVillaIndividual(int id)
		//{
		//    if (id == 0)
		//    {
		//        //  _logger.Log("Getting All villas Error with Id " +id,"error");
		//        return BadRequest();

		//    }
		//    // var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);

		//    //  var villa = _db.Villas1.FirstOrDefault(u => u.Id == id);

		//    //  var villa =await  _db.Villas1.FirstOrDefaultAsync(u => u.Id == id);

		//    var villa = await _dbRepos.Get(u => u.Id == id);

		//    if (villa == null)
		//    {
		//        return NotFound();
		//    }
		//    _response.Result = _mapper.Map<VillaDTO>(villa);

		//    _response.statusCode = HttpStatusCode.OK;

		//    return Ok(_response);
		//    //  return Ok(villa);
		//}
		///*
		//  public IEnumerable<VillaDTO> GetVillas()
		//  {
		//      return villaStore.villaList;
		//  }
		//  [HttpGet("id:int")]
		//  public VillaDTO GetVillaIndividual(int id=1)
		//  {
		//      return villaStore.villaList.FirstOrDefault(u=>u.Id ==id);
		//  }

		//      public IEnumerable<VillaDTO> GetVillas()
		//       {
		//           return new List<VillaDTO>() {
		//           new VillaDTO{ Id =1 , Name ="Nidhi Raparia" },
		//           new VillaDTO { Id = 2, Name = "Beach View" }

		//       };
		//       }

		//        public IEnumerable<Villa> GetVillas()
		//       {
		//         return new List<Villa>() {
		//       new Villa{ Id =1 , Name ="Pool View" },
		//       new Villa { Id = 2, Name = "Beach View" }

		//       };
		//  */

		//[HttpPost]
		//// undocumented 
		////[ProducesResponseType(200,Type =typeof(VillaDTO))]
		//[ProducesResponseType(StatusCodes.Status200OK)]
		//[ProducesResponseType(404)]

		//[ProducesResponseType(500)]

		////  public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO) {

		//// seperate create DTO
		//// public async Task<ActionResult<VillaDTO>> CreateVilla([FromBody] VillaDTOCreateTable villaDTO) {

		///*     if(!ModelState.IsValid)
		//         {
		//             return BadRequest(ModelState);
		//         }
		//    */
		//// if (villaStore.villaList.FirstOrDefault
		////        (u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null) {



		//// if (_db.Villas1.FirstOrDefault
		////       (u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
		//public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaDTOCreateTable villaDTO)
		//{

		//    if (await _dbRepos.Get(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
		//    {
		//        ModelState.AddModelError("Custom error", "Villa already Exists");
		//        return BadRequest(ModelState);

		//    }
		//    if (villaDTO == null)
		//    {
		//        return BadRequest(villaDTO);
		//    }


		//    //if (villaDTO.Id > 0)
		//    //{
		//    //    return StatusCode(StatusCodes.Status500InternalServerError);
		//    //}


		//    //villaDTO.Id = villaStore.villaList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

		//    Villa model = _mapper.Map<Villa>(villaDTO);
		//    // above is equal tp below
		//    // Villa model = new()
		//    // { 
		//    // Name = villaDTO.Name,
		//    // Amenity = villaDTO.Amenity,
		//    // Details = villaDTO.Details,
		//    //// Id = villaDTO.Id,
		//    // imgUrl = villaDTO.imgUrl,

		//    // occupancy = villaDTO.occupancy,
		//    // Rate = villaDTO.Rate,
		//    // sqft = villaDTO.sqft

		//    // };

		//    //_db.Villas1.Add(model);
		//    //_db.SaveChanges();

		//    await _dbRepos.Create(model);
		//    //   villaStore.villaList.Add(villaDTO);

		//    //   return Ok(villaDTO);

		//    //   return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);

		//    _response.Result = _mapper.Map<VillaDTO>(model);

		//    _response.statusCode = HttpStatusCode.Created;


		//    return CreatedAtRoute("GetVilla", new { id = model.Id }, model);


		//}

		//[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//[HttpDelete("{id:int}", Name = "DeleteVilla")]
		//public async Task<IActionResult> DeleteVilla(int id)

		//{
		//    if (id == 0)
		//    {
		//        return BadRequest();
		//    }
		//    //    var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
		//    var villa = await _dbRepos.Get(u => u.Id == id);

		//    if (villa == null)
		//    {
		//        return NotFound();

		//    }
		//    //   villaStore.villaList.Remove(villa);

		//    //   _db.Villas1.Remove(villa);
		//    // _db.SaveChanges();
		//    await _dbRepos.Remove(villa);

		//    return NoContent();
		//}


		//[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]
		//[ProducesResponseType(StatusCodes.Status400BadRequest)]
		//[HttpPut("{id:int}", Name = "updateVilla")]
		//public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDTOUpdateTable villaDTO)
		//{

		//    if (villaDTO == null || id != villaDTO.Id)
		//    {
		//        return BadRequest();
		//    }
		//    //var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
		//    //villa.Name = villaDTO.Name;
		//    //villa.sqft = villaDTO.sqft;
		//    //villa.occupancy=villaDTO.occupancy;




		//    Villa model = new()
		//    {
		//        Name = villaDTO.Name,
		//        Amenity = villaDTO.Amenity,
		//        Details = villaDTO.Details,
		//        Id = villaDTO.Id,
		//        imgUrl = villaDTO.imgUrl,

		//        occupancy = villaDTO.occupancy,
		//        Rate = villaDTO.Rate,
		//        sqft = villaDTO.sqft

		//    };

		//    // _db.Villas1.Update(model);
		//    // _db.SaveChanges();

		//    await _dbRepos.Update(model);

		//    return NoContent();
		//}



		//[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]

		//[ProducesResponseType(StatusCodes.Status204NoContent)]
		//[ProducesResponseType(StatusCodes.Status404NotFound)]


		//// public IActionResult UpdatePartialVilla(int id , JsonPatchDocument<VillaDTO>patchDto)
		//public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaDTOUpdateTable> patchDto)

		//{
		//    if (patchDto == null || id == 0)
		//    {
		//        return BadRequest();
		//    }

		//    // var villa = villaStore.villaList.FirstOrDefault(u => u.Id == id);
		//    // var villa = _db.Villas1.FirstOrDefault(u => u.Id == id);

		//    var villa = await _dbRepos.Get(u => u.Id == id);

		//    VillaDTOUpdateTable VillaDTO = new()
		//    //VillaDTO VillaDTO = new()

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
		//    //   patchDto.ApplyTo(villa, ModelState);
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

		//    //   _db.Villas1.Update(model);
		//    //   _db.SaveChanges();

		//    await _dbRepos.Update(model);



		//    if (ModelState.IsValid)
		//    {
		//        return BadRequest(ModelState);

		//    }
		//    return NoContent();
		//}



	}






