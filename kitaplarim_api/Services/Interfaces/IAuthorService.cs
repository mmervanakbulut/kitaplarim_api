using kitaplarim_api.DTOs.AuthorDTOs;
using kitaplarim_api.Models;

namespace kitaplarim_api.Services.Interfaces
{
	public interface IAuthorService
	{
		Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync();
		Task<Author> AddAuthorAsync(AuthorCreateDto request);
	}
}
