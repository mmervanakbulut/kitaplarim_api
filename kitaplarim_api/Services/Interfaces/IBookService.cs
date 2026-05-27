using kitaplarim_api.DTOs.BookDTOs;
using kitaplarim_api.Models;

namespace kitaplarim_api.Services.Interfaces
{
	public interface IBookService
	{
		Task<IEnumerable<BookResponseDto>> GetMyBooksAsync(int userId);
		Task<Book> AddBookAsync(BookCreateDto request, int userId);
	}
}
