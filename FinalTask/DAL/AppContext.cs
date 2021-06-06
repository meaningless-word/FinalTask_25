using FinalTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.DAL
{
	public class AppContext: DbContext
	{
		// объекты таблицы Users
		public DbSet<User> Users { get; set; }

		// объекты таблицы Genres
		public DbSet<Genre> Genres { get; set; }

		// объекты таблицы Authors
		public DbSet<Author> Authors { get; set; }

		// бъекты таблицы Books
		public DbSet<Book> Books { get; set; }

		public AppContext()
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(local);Database=Library;Trusted_Connection=True;");
		}
	}
}
