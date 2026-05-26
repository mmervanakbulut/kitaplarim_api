using kitaplarim_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kitaplarim_api.Configurations
{
	public class AuthorConfiguration : IEntityTypeConfiguration<Author>
	{
		public void Configure(EntityTypeBuilder<Author> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			builder.Property(x => x.Surname)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			builder.Property(x => x.Description)
				.HasMaxLength(200)
				.IsUnicode(true);
		}
	}
}
