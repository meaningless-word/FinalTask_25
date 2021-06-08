using FinalTask.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	/// <summary>
	/// класс базовых функций для операций над сущностью "авторы книг"
	/// </summary>
	public class AuthorRepository
	{
		private AppContext db;

		public AuthorRepository(AppContext db)
		{
			this.db = db;
		}
		/// <summary>
		/// создание
		/// </summary>
		/// <param name="entity"></param>
		public void Create(Author entity)
		{
			db.Authors.Add(entity);
		}
		/// <summary>
		/// чтение записи по идентификатору
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns></returns>
		public Author Read(int id)
		{
			return  db.Authors.Where(x => x.Id == id).FirstOrDefault();
		}
		/// <summary>
		/// чтение записи по имени
		/// </summary>
		/// <param name="name">имя</param>
		/// <returns></returns>
		public Author Read(string name)
		{
			return db.Authors.Where(x => x.Name == name).FirstOrDefault();
		}
		/// <summary>
		/// чтение всех записей
		/// </summary>
		/// <returns></returns>
		public List<Author> ReadAll()
		{
			return db.Authors.ToList();
		}
		/// <summary>
		/// изменение записи
		/// </summary>
		/// <param name="entity"></param>
		public void Update(Author entity)
		{
			db.Authors.Update(entity);
		}
		/// <summary>
		/// удаление записи
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(Author entity)
		{
			db.Authors.Remove(entity);
		}
	}
}
