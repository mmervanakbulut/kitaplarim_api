namespace kitaplarim_api.Models
{
	public class User
	{
		public int Id { get; set; }
		public required string Nickname { get; set; }
		public required string Email { get; set; }
		public string? HashedPassword { get; set; }

		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
