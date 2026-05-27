using kitaplarim_api.DTOs.AuthorDTOs;
using kitaplarim_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kitaplarim_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class AuthorController(IAuthorService authorService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllAuthors()
		{
			var authors = await authorService.GetAllAuthorsAsync();
			return Ok(authors);
		}

		[HttpPost]
		public async Task<IActionResult> AddAuthor([FromBody] AuthorCreateDto request)
		{
			var newAuthor = await authorService.AddAuthorAsync(request);
			return Ok(newAuthor);
		}
	}
}
