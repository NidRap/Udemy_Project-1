using ConsumingApiSection.Models.Models;
using ConsumingApiSection.Services.IServices;
using ConsumingApiSection.Services;
using Utility;
using ConsumingApiSection.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ConsumingApiSection.Models;

namespace ConsumingApiSection.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> list = new();


            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }


		public async Task<IActionResult> CreateVilla()
		{


			return View();

		}


		[HttpPost]
		[ValidateAntiForgeryToken]

		public async Task<IActionResult> CreateVilla(VillaNumberCreateDTO model)
		{
			if (ModelState.IsValid)
			{
				var response = await _villaNumberService.GetAllAsync<APIResponse>();
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexVillaNumber));
				}
			}
			return View(model);

		}


		public async Task<IActionResult> UpdateVilla(int villaId)
		{
			try
			{
				var response = await _villaNumberService.GetAsync<APIResponse>(villaId);
				if (response != null && response.IsSuccess)
				{
					VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
					return View(_mapper.Map<VillaDTOUpdateTable>(model));
				}
				return NotFound();

			}
			catch (Exception ex)
			{
				return null;
			}
			

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateVilla(VillaNumberUpdateDTO model)
		{
			if (ModelState.IsValid)
			{

				var response = await _villaNumberService.UpdateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
					return RedirectToAction(nameof(IndexVillaNumber));
				}
			}
			return View(model);
		}

		public async Task<IActionResult> DeleteVilla(int villaId)
		{
			var response = await _villaNumberService.GetAsync<APIResponse>(villaId);
			if (response != null && response.IsSuccess)
			{
				VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}

		[HttpPost]
	
		public async Task<IActionResult> DeleteVilla(VillaDTO model)
		{

			var response = await _villaNumberService.DeleteAsync<APIResponse>(model.Id);
			if (response != null && response.IsSuccess)
			{
				return RedirectToAction(nameof(IndexVillaNumber));
			}

			return View(model);
		}
	}
}
