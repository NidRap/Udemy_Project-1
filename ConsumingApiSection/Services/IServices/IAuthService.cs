using ConsumingApiSection.Models.DTO;

namespace ConsumingApiSection.Services.IServices
{
	public interface IAuthService
	{
		Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
		Task<T> RegisterAsync<T>(RegistrationRequestDTO objToCreate);
	}
}
