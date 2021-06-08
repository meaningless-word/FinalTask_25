using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// литературные жанры
	/// </summary>
	public class Genre
	{
		/// <summary>
		/// идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// наименование
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// ссылка на книги - навигационное свойство (один-ко-многим)
		/// </summary>
		public List<Book> Books { get; set; } = new List<Book>();

		public Genre(string name)
		{
			Name = name;
		}
	}
}
