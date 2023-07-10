using ConsumingApiSection.Models.Models.DTO;

namespace ConsumingApiSection.Models.DTO
{
	public class LoginResponseDTO
	{
		public UserDTO User { get; set; }
		public string Token { get; set; }
	}
}
