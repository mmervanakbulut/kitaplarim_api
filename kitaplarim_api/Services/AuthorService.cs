using kitaplarim_api.Data;
using kitaplarim_api.DTOs.AuthorDTOs;
using kitaplarim_api.Models;
using kitaplarim_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace kitaplarim_api.Services
{
	public class AuthorService(AppDbContext context) : IAuthorService
	{
		public async Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync()
		{
			return await context.Authors
				.AsNoTracking()
				.Select(a => new AuthorResponseDto(a.Id, a.Name + " " + a.Surname, a.Description))
				.ToListAsync();
		}

		public async Task<Author> AddAuthorAsync(AuthorCreateDto request)
		{
			var author = new Author
			{
				Name = request.Name,
				Surname = request.Surname,
				Description = request.Description ?? string.Empty
			};

			context.Authors.Add(author);
			await context.SaveChangesAsync();

			return author;
		}
	}
}
