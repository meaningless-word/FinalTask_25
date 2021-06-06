using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// книги
	/// </summary>
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int YearOfIssue { get; set; }

		/// <summary>
		/// ссылка на жанр
		/// </summary>
		public int GenreId { get; set; }
		// навигационное свойство (один-ко-многим)
		public Genre Genre { get; set; }

		// ссылка на авторов - навигационное свойство (многие-ко-многим)
		public List<Author> Authors { get; set; } = new List<Author>();

		// ссылка на читателей - навигационное свойство (многие-ко-многим)
		public List<User> Readers { get; set; } = new List<User>();
	}
}
