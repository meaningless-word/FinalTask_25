using FinalTask.BLL.Exceptions;
using FinalTask.BLL.Models;
using FinalTask.DAL.Entities;
using FinalTask.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.BLL.Services
{
	enum BookReadOptions
	{
		ByGenre = 1,
		ByAuthor = 2
	}

	public class BookService
	{
		BookRepository bookRepository;

		public BookService()
		{
			bookRepository = new BookRepository();
		}

		public void Create (BookDTO book)
		{
			Book entity = new Book();

			entity.GenreId = Program.genreService.CreateIfNotExists(new GenreDTO() { Name = book.Genre }).Id;
			entity.Title = book.Title;
			entity.YearOfIssue = book.YearOfIssue;

			bookRepository.Create(entity);

			entity = bookRepository.Read(book.Title, book.YearOfIssue, Program.genreService.CreateIfNotExists(new GenreDTO() { Name = book.Genre }).Id);
			// авторы
			List<Author> authors = Program.authorService.CreateIfNotExist(new AuthorDTO() { Name = book.Authors });
			entity.Authors.AddRange(authors);
			bookRepository.Update(entity.Id, entity);
		}

		public List<BookDTO> ReadAll()
		{
			List<Book> books = bookRepository.ReadAll();
			return books.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Select(y => y.Name).ToArray()) , x.Genre.Name)).ToList();
		}

		public bool IsTheBookInLibrary(string Title, string Author)
		{
			try
			{
				Book entity = bookRepository.Read(Title, Author);
				return true;
			}
			catch (BookNotFoundException)
			{
				return false;
			}
		}

		public List<BookDTO> ReadByGenre(string genreName)
		{
			return bookRepository.Read(genreName, (int)BookReadOptions.ByGenre)
				.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Select(y => y.Name).ToArray()), x.Genre.Name))
				.ToList();
		}

		public List<BookDTO> ReadByAuthor(string authorName)
		{
			return bookRepository.Read(authorName, (int)BookReadOptions.ByAuthor)
				.Select(x => new BookDTO(x.Id, x.Title, x.YearOfIssue, String.Join(", ", x.Authors.Where(y => y.Name.Contains(authorName)).Select(z => z.Name).ToArray()), x.Genre.Name))
				.ToList();
		}

		public List<BookDTO> ReadByGenreInPeriod(string genreName, int yearAfter, int yearBefore)
		{

		}

		public void Update(int id, BookDTO book)
		{
			Book entity = bookRepository.Read(id);
			entity.YearOfIssue = book.YearOfIssue;

			bookRepository.Update(id, entity);
		}
	}
}
