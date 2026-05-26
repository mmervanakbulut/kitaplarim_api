namespace kitaplarim_api.Models
{
	public class Book
	{
		public required int Id { get; set; }
		public required string Title { get; set; }
		public required string BookType { get; set; }
		public required int PageCount { get; set; }
		public required string ShelfLocation { get; set; } = string.Empty;

		public required int AuthorId { get; set; }
		public required Author Author { get; set; }

		public required int UserId { get; set; }
		public required User User { get; set; }

		public required int PublisherId { get; set; }
		public required Publisher Publisher { get; set; }
	}
}
