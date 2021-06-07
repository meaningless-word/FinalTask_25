using System.Collections.Generic;

namespace FinalTask.DAL.Entities
{
	/// <summary>
	/// пользователи электронной библиотеки
	/// </summary>
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public List<Book> ReadedBooks { get; set; } = new List<Book>();

		public User(string name, string email)
		{
			Name = name;
			Email = email;
		}

	}
}
