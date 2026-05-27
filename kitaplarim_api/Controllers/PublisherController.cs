using kitaplarim_api.DTOs.PublisherDTOs;
using kitaplarim_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kitaplarim_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class PublisherController(IPublisherService publisherService) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllPublishers()
		{
			var publishers = await publisherService.GetAllPublishersAsync();
			return Ok(publishers);
		}

		[HttpPost]
		public async Task<IActionResult> AddPublisher([FromBody] PublisherCreateDto request)
		{
			var newPublisher = await publisherService.AddPublisherAsync(request);
			return Ok(newPublisher);
		}
	}
}
