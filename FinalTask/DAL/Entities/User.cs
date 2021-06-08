using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// пользователи электронной библиотеки
	/// </summary>
	public class User
	{
		/// <summary>
		/// идентификатор
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// имя пользователя
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// e-mail пользователя
		/// </summary>
		public string Email { get; set; }
		/// <summary>
		/// ссылка на прочитанные книги - навигационное свойство (многие-ко многим)
		/// </summary>
		public List<Book> ReadedBooks { get; set; } = new List<Book>();

		public User(string name, string email)
		{
			Name = name;
			Email = email;
		}

	}
}
