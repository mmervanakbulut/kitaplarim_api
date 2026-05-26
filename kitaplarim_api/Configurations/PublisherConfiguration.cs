using kitaplarim_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kitaplarim_api.Configurations
{
	public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
	{
		public void Configure(EntityTypeBuilder<Publisher> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100)
				.IsUnicode(true);
		}
	}
}
