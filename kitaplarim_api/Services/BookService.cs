using kitaplarim_api.Data;
using kitaplarim_api.DTOs.BookDTOs;
using kitaplarim_api.Models;
using kitaplarim_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace kitaplarim_api.Services
{
	public class BookService(AppDbContext context) : IBookService
	{
		public async Task<IEnumerable<BookResponseDto>> GetMyBooksAsync(int userId)
		{
			var myBooks = await context.Books
				.AsNoTracking()
				.Where(x => x.UserId == userId)
				.Select(x => new BookResponseDto(
					x.Id,
					x.Title,
					x.BookType,
					x.PageCount,
					x.ShelfLocation,
					x.Author.Name + " " + x.Author.Surname,
					x.Publisher.Name
				))
				.ToListAsync();
			return myBooks;
		}
		public async Task<Book> AddBookAsync(BookCreateDto request, int userId)
		{
			var newBook = new Book
			{
				Title = request.Title,
				PageCount = request.PageCount,
				ShelfLocation = request.ShelfLocation,
				UserId = userId,
				AuthorId = request.AuthorId,
				PublisherId = request.PublisherId,
				BookType = request.BookType
			};
			context.Books.Add(newBook);
			await context.SaveChangesAsync();
			return newBook;
		}
	}
}
