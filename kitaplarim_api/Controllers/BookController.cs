using kitaplarim_api.DTOs.BookDTOs;
using kitaplarim_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace kitaplarim_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class BookController(IBookService bookService) : ControllerBase
	{

		private int? GetCurrentUserId()
		{
			var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return int.TryParse(userIdStr, out int userId) ? userId : null;
		}

		[HttpGet]
		public async Task<IActionResult> GetMyBooks()
		{
			var userId = GetCurrentUserId();

			if (userId is null)
			{ 
				return Unauthorized("User identity is invalid."); 
			}

			var myBooks = await bookService.GetMyBooksAsync(userId.Value);

			return Ok(myBooks);
		}

		[HttpPost]
		public async Task<IActionResult> AddBook([FromBody] BookCreateDto request)
		{
			var userId = GetCurrentUserId();

			if (userId is null)
			{
				return Unauthorized("User identity is invalid.");
			}

			var newBook = await bookService.AddBookAsync(request, userId.Value);

			return Ok(newBook);
		}
	}
}
