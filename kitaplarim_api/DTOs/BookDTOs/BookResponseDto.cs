namespace kitaplarim_api.DTOs.BookDTOs
{
	public record class BookResponseDto(
		int Id,
		string Title,
		string BookType,
		int PageCount,
		string ShelfLocation,
		string AuthorFullName,
		string PublisherName
		);
}
