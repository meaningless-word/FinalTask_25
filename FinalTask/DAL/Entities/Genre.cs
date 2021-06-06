using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// литературные жанры
	/// </summary>
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		// навигационное свойство (один-ко-многим)
		public List<Book> Books { get; set; } = new List<Book>();
	}
}
