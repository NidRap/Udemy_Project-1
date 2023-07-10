using Udemy_Project_1.Models.DTO;
using Udemy_Project_1.Models;

namespace Udemy_Project_1.Repository
{
	public interface IUserRepository
	{
		bool IsUniqueUser(string username);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
		Task<LocalUser> Register(RegistrationRequestDTO registerationRequestDTO);
	}
}
