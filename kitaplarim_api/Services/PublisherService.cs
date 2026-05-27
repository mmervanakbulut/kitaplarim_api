using kitaplarim_api.Data;
using kitaplarim_api.DTOs.PublisherDTOs;
using kitaplarim_api.Models;
using kitaplarim_api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace kitaplarim_api.Services
{
	public class PublisherService(AppDbContext context) : IPublisherService
	{
		public async Task<Publisher> AddPublisherAsync(PublisherCreateDto request)
		{
			var publisher = new Publisher
			{
				Name = request.Name
			};

			context.Publishers.Add(publisher);
			await context.SaveChangesAsync();

			return publisher;
		}

		public async Task<IEnumerable<PublisherResponseDto>> GetAllPublishersAsync()
		{
			return await context.Publishers
				.AsNoTracking()
				.Select(p => new PublisherResponseDto(p.Id, p.Name))
				.ToListAsync();
		}
	}
}
