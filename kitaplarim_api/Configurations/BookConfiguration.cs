using kitaplarim_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kitaplarim_api.Configurations
{
	public class BookConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(200)
				.IsUnicode(true);

			builder.Property(x => x.BookType)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			builder.HasOne(x => x.Author)
				.WithMany(a => a.Books)
				.HasForeignKey(x => x.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.User)
				.WithMany(u => u.Books)
				.HasForeignKey(x => x.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(x => x.Publisher)
				.WithMany(u => u.Books)
				.HasForeignKey(x => x.PublisherId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.HasIndex(x => x.UserId);
			builder.HasIndex(x => x.AuthorId);
			builder.HasIndex(x => x.PublisherId);
		}
	}
}
