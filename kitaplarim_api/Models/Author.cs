namespace kitaplarim_api.Models
{
	public class Author
	{
		public int Id { get; set; }
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public string Description { get; set; } = string.Empty;

		public ICollection<Book> Books { get; set; } = new List<Book>();
	}
}
