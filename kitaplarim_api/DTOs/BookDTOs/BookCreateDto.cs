namespace kitaplarim_api.DTOs.BookDTOs
{
	public class BookCreateDto
	{
		public required string Title { get; set; }
		public required string BookType { get; set; }
		public required int PageCount { get; set; }
		public string ShelfLocation { get; set; } = string.Empty;
		public required int AuthorId { get; set; }
		public required int PublisherId { get; set; }
	}
}
