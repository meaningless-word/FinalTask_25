using FinalTask.BLL.Exceptions;
using FinalTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	public class BookRepository : IRepository<Book>, IDisposable
	{
		private AppContext db;

		public BookRepository()
		{
			db = new AppContext();
		}

		public void Create(Book entity)
		{
			db.Books.Add(entity);
			db.SaveChanges();
		}

		public Book Read(int id)
		{
			Book item = db.Books.Where(x => x.Id == id).FirstOrDefault();
			if (item is null) throw new BookNotFoundException();

			return item;
		}

		public Book Read(string Title, int YearOfIssue, int GenreId)
		{
			Book item = db.Books.Where(x => x.Title == Title && x.YearOfIssue == YearOfIssue && x.GenreId == GenreId).FirstOrDefault();
			if (item is null) throw new BookNotFoundException();

			return item;
		}

		public Book Read(string Title, string Author)
		{
			Book item = db.Books.Include("Authors").Where(x => x.Title.Contains(Title) && x.Authors.Where(y => y.Name.Contains(Author)).ToList().Count > 0).FirstOrDefault();
			if (item is null) throw new BookNotFoundException();

			return item;
		}

		public List<Book> Read(string partOfName, int choise)
		{
			var result = new List<Book>();
			switch (choise)
			{
				case 1:
					{
						result = db.Books.Include("Authors").Include("Genre").Where(x => x.Genre.Name.Contains(partOfName)).ToList();
						break;
					}
				case 2:
					{
						result = db.Books.Include("Authors").Include("Genre").Where(x => x.Authors.Where(y => y.Name.Contains(partOfName)).ToList().Count > 0).ToList();
						break;
					}
			}
			return result;
		}

		public List<Book> ReadAll()
		{
			return db.Books.Include("Authors").Include("Genre").ToList();
		}

		public void Update(int id, Book entity)
		{
			Book item = Read(id);
			item.Title = entity.Title;
			item.YearOfIssue = entity.YearOfIssue;
			item.GenreId = entity.GenreId;
			item.Authors = entity.Authors;
			item.Readers = entity.Readers;
			db.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
