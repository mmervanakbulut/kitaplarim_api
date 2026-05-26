using kitaplarim_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace kitaplarim_api.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Publisher> Publishers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(modelBuilder);
		}
	}
}
