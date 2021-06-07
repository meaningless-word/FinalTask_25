using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// авторы книг
	/// </summary>
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
		/// <summary>
		/// авторство
		/// </summary>
		public List<Book> Authorship { get; set; } = new List<Book>();

		public Author(string name)
		{
			Name = name;
		}
	}
}
