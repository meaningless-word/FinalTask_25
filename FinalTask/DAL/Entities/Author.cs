using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// авторы книг
	/// </summary>
	public class Author
	{
		/// <summary>
		/// идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// имя
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// авторство (соавторство) - навигационное свойство (многие-ко-многим)
		/// </summary>
		public List<Book> Authorship { get; set; } = new List<Book>();

		public Author(string name)
		{
			Name = name;
		}
	}
}
