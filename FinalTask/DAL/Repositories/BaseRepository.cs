using System;

namespace FinalTask.DAL.Repositories
{
	/// <summary>
	/// класс базовых функций работы с базой данных, объединяющий управление сущностями
	/// </summary>
	public class BaseRepository : IDisposable
	{
		private AppContext db;

		public GenreRepository genreRepository;
		public AuthorRepository authorRepository;
		public BookRepository bookRepository;
		public UserRepository userRepository;

		public BaseRepository()
		{
			db = new AppContext();
			genreRepository = new GenreRepository(db);
			authorRepository = new AuthorRepository(db);
			bookRepository = new BookRepository(db);
			userRepository = new UserRepository(db);
		}

		public void Save()
		{
			db.SaveChanges();
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
