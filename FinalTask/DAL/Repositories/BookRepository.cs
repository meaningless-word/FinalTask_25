using FinalTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	/// <summary>
	/// класс базовых функций для операций над сущностью "книги"
	/// </summary>
	public class BookRepository
	{
		private AppContext db;

		public BookRepository(AppContext db)
		{
			this.db = db;
		}
		/// <summary>
		/// создание
		/// </summary>
		/// <param name="entity"></param>
		public void Create(Book entity)
		{
			db.Books.Add(entity);
		}
		/// <summary>
		/// чтение записи по идентификатору
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns></returns>
		public Book Read(int id)
		{
			return db.Books.Where(x => x.Id == id).FirstOrDefault();
		}
		/// <summary>
		/// чтение записи по :
		/// </summary>
		/// <param name="Title">наименование книги</param>
		/// <param name="YearOfIssue">год издания</param>
		/// <param name="GenreId">идетификтор жанра</param>
		/// <returns></returns>
		public Book Read(string Title, int YearOfIssue, int GenreId)
		{
			return db.Books.Where(x => x.Title == Title && x.YearOfIssue == YearOfIssue && x.GenreId == GenreId).FirstOrDefault();
		}
		/// <summary>
		/// чтение записи по фрагменту :
		/// </summary>
		/// <param name="partOfTitle">части наименования</param>
		/// <param name="partOfAuthor">части имени автора</param>
		/// <param name="partOfGenre">части наименования жанра</param>
		/// <returns></returns>
		public List<Book> Read(string partOfTitle, string partOfAuthor, string partOfGenre)
		{
			return db.Books.Include("Authors").Include("Genre").Where(x => x.Title.Contains(partOfTitle) && x.Authors.Where(y => y.Name.Contains(partOfAuthor)).ToList().Count > 0 && x.Genre.Name.Contains(partOfGenre)).ToList();
		}
		/// <summary>
		/// чтение всех записей
		/// </summary>
		/// <returns></returns>
		public List<Book> ReadAll()
		{
			return db.Books.Include("Authors").Include("Genre").ToList();
		}
		/// <summary>
		/// изменение записи
		/// </summary>
		/// <param name="entity"></param>
		public void Update(Book entity)
		{
			db.Books.Update(entity);
		}
		/// <summary>
		/// удаление записи
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(Book entity)
		{
			db.Books.Remove(entity);
		}
	}
}
