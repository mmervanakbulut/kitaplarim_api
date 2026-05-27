using kitaplarim_api.DTOs.PublisherDTOs;
using kitaplarim_api.Models;

namespace kitaplarim_api.Services.Interfaces
{
	public interface IPublisherService
	{
		Task<IEnumerable<PublisherResponseDto>> GetAllPublishersAsync();
		Task<Publisher> AddPublisherAsync(PublisherCreateDto request);
	}
}
