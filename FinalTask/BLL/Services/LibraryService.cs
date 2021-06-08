using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.DAL.Entities;
using FinalTask.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.BLL.Services
{
	/// <summary>
	/// класс сервисных методов управления запросами
	/// </summary>
	public class LibraryService : IDisposable
	{
		private BaseRepository baseRepository;

		public LibraryService()
		{
			baseRepository = new BaseRepository();
		}

		public void Dispose()
		{
			baseRepository.Dispose();
		}

		#region Creates
		/// <summary>
		/// запрос на создание книги
		/// </summary>
		/// <param name="book">модель обмена данными</param>
		/// <returns>модель сущности</returns>
		public Book Create(BookDTO book)
		{
			GenreDTO genre = new GenreDTO() { Name = book.Genre }; // создание модели для жанра
			Genre _genre = Create(genre); // создание сущности указанного жанра в случае его отсутствия

			Book _book = baseRepository.bookRepository.Read(book.Title, book.YearOfIssue, _genre.Id); // получение сущности "книга" для указанных наименования, года издания и жанра
			if (_book is null) // в случае отсутсвия запрашиваемой сущности, создаётся новая
			{
				// создание списка авторов, в случае, если указан авторский коллектив
				string[] authors = book.Authors.Split(",");
				var _authors = new List<Author>(); 
				for (int i = 0; i < authors.Length; i++) // на каждый элемент этого списка
				{
					AuthorDTO author = new AuthorDTO() { Name = authors[i] }; // получение сущности "автор" по имени
					_authors.Add(Create(author)); // с созданием при отсутствии и накоплением в список ссылок для навигационного поля сущности "книга"
				}

				_book = new Book(); // создание сущности "книга" и заполнение свойств
				_book.GenreId = _genre.Id; // навигационне свойство со ссылкой на жанр
				_book.Title = book.Title;
				_book.YearOfIssue = book.YearOfIssue;
				_book.Authors = _authors; // навигационное свойство со списком ссылок на авторов
				baseRepository.bookRepository.Create(_book); 
				baseRepository.Save();
			}
			return _book;
		}
		/// <summary>
		/// запрос на создание жанра
		/// </summary>
		/// <param name="genre">модель обмена данными</param>
		/// <returns>модель сущности</returns>
		public Genre Create(GenreDTO genre)
		{
			Genre _genre = baseRepository.genreRepository.Read(genre.Name); // получение сущности "жанр" по наименованию
			if (_genre is null) // в случае отсутствия сущности, создаётся новая
			{
				_genre = new Genre(genre.Name); 
				baseRepository.genreRepository.Create(_genre);
				baseRepository.Save();
			}
			return _genre;
		}
		/// <summary>
		/// запрос на создание автора
		/// </summary>
		/// <param name="author">модель обмена данными</param>
		/// <returns>модель сущности</returns>
		public Author Create(AuthorDTO author)
		{
			Author _author = baseRepository.authorRepository.Read(author.Name); // получение сущности "автор" по имени
			if (_author is null) // в случае отсутствия сущности, создаётся новая
			{
				_author = new Author(author.Name);
				baseRepository.authorRepository.Create(_author);
				baseRepository.Save();
			}
			return _author;
		}
		/// <summary>
		/// запрос на создание пользователя
		/// </summary>
		/// <param name="user">модель обмена данными</param>
		/// <returns>модель сущности</returns>
		public User Create(UserDTO user)
		{
			User _user = baseRepository.userRepository.Read(user.Name, user.Email); // получение сущности "автор" по имени и e-mail'у
			if (_user is null) // в случае отсутствия сущности, создаётся новая
			{
				_user = new User(user.Name, user.Email);
				baseRepository.userRepository.Create(_user);
				baseRepository.Save();
			}
			return _user;
		}
		#endregion

		#region ReadAlls
		/// <summary>
		/// запрос на получение всех сущностей "книга"
		/// </summary>
		/// <returns>список моделей обмена данными "книга"</returns>
		public List<BookDTO> ReadAllBooks()
		{
			List<Book> books = baseRepository.bookRepository.ReadAll();
			return books.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Select(y => y.Name).ToArray()), x.Genre.Name)).ToList();
		}
		/// <summary>
		/// запрос на получение всех сущностей "жанр"
		/// </summary>
		/// <returns>список моделей обмена данными "жанр"</returns>
		public List<GenreDTO> ReadAllGenres()
		{
			List<Genre> genres = baseRepository.genreRepository.ReadAll();
			return genres.Select(x => new GenreDTO(x.Id, x.Name)).ToList();
		}
		/// <summary>
		/// запрос на получение всех сущностей "пользователь"
		/// </summary>
		/// <returns>список моделей обмена данными "пользователь"</returns>
		public List<UserDTO> ReadAllUsers()
		{
			List<User> users = baseRepository.userRepository.ReadAll();
			return users.Select(x => new UserDTO(x.Id, x.Name, x.Email, x.ReadedBooks.Count)).ToList();
		}
		/// <summary>
		/// запрос на получение всех сущностей "автор"
		/// </summary>
		/// <returns>список моделей обмена данными "автор"</returns>
		public List<AuthorDTO> ReadAllAuthors()
		{
			List<Author> authors = baseRepository.authorRepository.ReadAll();
			return authors.Select(x => new AuthorDTO(x.Id, x.Name)).ToList();
		}
		#endregion

		#region ReadByIds
		/// <summary>
		/// запрос на чтение сушности "пользователь" по идентификатору
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns>модель обмена данными "пользователь"</returns>
		public UserDTO ReadUserById(int id)
		{
			User user = baseRepository.userRepository.Read(id);
			if (user is null) throw new UserNotFoundException();
			return new UserDTO(user.Id, user.Name, user.Email, user.ReadedBooks.Count);
		}
		#endregion

		#region ReadBySomething
		/// <summary>
		/// запрос на получение сущностей "книга" при вхождении указанных параметров в :
		/// </summary>
		/// <param name="Title">наименование книги</param>
		/// <param name="Author">имя автора</param>
		/// <returns></returns>
		public List<BookDTO> ReadBooksByPartsTitleAndAuthor(string Title, string Author)
		{
			List<Book> books = baseRepository.bookRepository.Read(Title, Author, "");
			return books.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Select(y => y.Name).ToArray()), x.Genre.Name)).ToList();
		}
		/// <summary>
		/// запрос на получение сущностей "книга" при вхождении указанных параметров в :
		/// </summary>
		/// <param name="Genre">наименование жанра</param>
		/// <returns></returns>
		public List<BookDTO> ReadBooksByGenre(string Genre)
		{
			List<Book> books = baseRepository.bookRepository.Read("", "", Genre);
			return books.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Select(y => y.Name).ToArray()), x.Genre.Name)).ToList();
		}
		/// <summary>
		/// запрос на получение сущностей "книга" при вхождении указанных параметров в :
		/// </summary>
		/// <param name="Author">имя автора</param>
		/// <returns></returns>
		public List<BookDTO> ReadBooksByAuthor(string Author)
		{
			List<Book> books = baseRepository.bookRepository.Read("", Author, "");
			return books.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Where(x => x.Name.Contains(Author)).Select(y => y.Name).ToArray()), x.Genre.Name)).ToList();
		}
		#endregion

		#region Inspectors
		/// <summary>
		/// проверка наличия в списке книг указанного пользователя указанной книги
		/// </summary>
		/// <param name="userId">идентификатор пользьвателя</param>
		/// <param name="bookId">идентификатор книги</param>
		/// <returns></returns>
		public bool IsUserHaveBook(int userId, int bookId)
		{
			User user = baseRepository.userRepository.Read(userId);
			if (user is null) throw new UserNotFoundException();
			Book book = baseRepository.bookRepository.Read(bookId);
			if (book is null) throw new BookNotFoundException();
			book = user.ReadedBooks.Where(x => x.Id == bookId).FirstOrDefault();
			if (book is null) return false;
			return true;
		}
		/// <summary>
		/// проверка наличия в библиотеке книги при вхождении указанных параметров в :
		/// </summary>
		/// <param name="Title">наименование</param>
		/// <param name="Author">имя авотра</param>
		/// <returns></returns>
		public bool IsTheBookInLibrary(string Title, string Author)
		{
			return (ReadBooksByPartsTitleAndAuthor(Title, Author).Count > 0);
		}

		#endregion

		#region Updates
		/// <summary>
		/// изменение года издания у сущности "книга"
		/// </summary>
		/// <param name="book">модель обмена данными</param>
		public void Update(BookDTO book)
		{
			Book _book = baseRepository.bookRepository.Read(book.Id);
			if (_book is null) throw new BookNotFoundException();
			_book.YearOfIssue = book.YearOfIssue;
			baseRepository.bookRepository.Update(_book);
			baseRepository.Save();
		}
		/// <summary>
		/// изменение наименования жанра у сущности "жанр"
		/// </summary>
		/// <param name="genre">модель обмена данными</param>
		public void Update(GenreDTO genre)
		{
			Genre _genre = baseRepository.genreRepository.Read(genre.Id);
			if (_genre is null) throw new GenreNotFoundException();
			_genre.Name = genre.Name;
			baseRepository.genreRepository.Update(_genre);
			baseRepository.Save();
		}
		/// <summary>
		/// изменение сущности "пользователь" в соответствии с модель обмена данными
		/// </summary>
		/// <param name="user">модель обмена данными</param>
		public void Update(UserDTO user)
		{
			User _user = baseRepository.userRepository.Read(user.Id);
			if (_user is null) throw new UserNotFoundException();
			if (user.GivedBookId != 0) // при непустом идентификаторе книги - добавление новой в список прочитанных
			{
				Book _book = baseRepository.bookRepository.Read(user.GivedBookId);
				if (_book is null) throw new BookNotFoundException();
				_user.ReadedBooks.Add(_book);
			}
			if (user.Name.Length > 0) // при непустом имени - замена имени
			{
				_user.Name = user.Name;
			}
			baseRepository.userRepository.Update(_user);
			baseRepository.Save();
		}
		#endregion

	}
}
