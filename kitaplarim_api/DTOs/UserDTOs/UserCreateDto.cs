namespace kitaplarim_api.DTOs.UserDTOs
{
	public class UserCreateDto
	{
		public required string Nickname { get; set; }
		public required string Email { get; set; }
		public required string Password { get; set; }
	}
}
