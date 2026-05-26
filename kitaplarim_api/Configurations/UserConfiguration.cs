using kitaplarim_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kitaplarim_api.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Nickname)
				.IsRequired()
				.HasMaxLength(50)
				.IsUnicode(true);

			builder.Property(x => x.Email)
				.IsRequired()
				.HasMaxLength(150)
				.IsUnicode(true);

			builder.HasIndex(x => x.Email)
				.IsUnique();

			builder.Property(x => x.PasswordHash)
				.IsRequired()
				.HasMaxLength(256)
				.IsUnicode(false);
		}
	}
}
