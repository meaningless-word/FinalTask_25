using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// книги
	/// </summary>
	public class Book
	{
		/// <summary>
		/// идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// наименование книги
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// год издания
		/// </summary>
		public int YearOfIssue { get; set; }
		/// <summary>
		/// ссылка на жанр
		/// </summary>
		public int GenreId { get; set; }
		// навигационное свойство (один-ко-многим)
		public Genre Genre { get; set; }
		/// <summary>
		/// ссылка на авторов - навигационное свойство (многие-ко-многим)
		/// </summary>
		public List<Author> Authors { get; set; } = new List<Author>();
		/// <summary>
		/// ссылка на читателей - навигационное свойство (многие-ко-многим)
		/// </summary>
		public List<User> Readers { get; set; } = new List<User>();
	}
}
