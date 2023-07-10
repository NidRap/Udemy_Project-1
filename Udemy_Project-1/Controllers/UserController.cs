using System.Net;
using Microsoft.AspNetCore.Mvc;
using Udemy_Project_1.Models;
using Udemy_Project_1.Models.DTO;
using Udemy_Project_1.Repository;

namespace Udemy_Project_1.Controllers
{

	[Route("api/UsersAuth")]
	[ApiController]
	public class UserController :Controller
	{ 
        private readonly IUserRepository _userRepo;
		protected APIResponse _response;
		public UserController(IUserRepository userRepo)
		{
			_userRepo = userRepo;
			this._response = new();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
		{
			var loginResponse = await _userRepo.Login(model);
			if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
			{
				_response.statusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorsMsg.Add("Username or password is incorrect");
				return BadRequest(_response);
			}
			_response.statusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			_response.Result = loginResponse;
			return Ok(_response);
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model)
		{
			bool ifUserNameUnique = _userRepo.IsUniqueUser(model.UserName);
			if (!ifUserNameUnique)
			{
				_response.statusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorsMsg.Add("Username already exists");
				return BadRequest(_response);
			}

			var user = await _userRepo.Register(model);
			if (user == null)
			{
				_response.statusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.ErrorsMsg.Add("Error while registering");
				return BadRequest(_response);
			}
			_response.statusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			return Ok(_response);
		}

	}
}
