using FinalTask.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	/// <summary>
	/// класс базовых функций для операций над сущностью "жанры"
	/// </summary>
	public class GenreRepository
	{
		private AppContext db;

		public GenreRepository(AppContext db)
		{
			this.db = db;
		}
		/// <summary>
		/// содание
		/// </summary>
		/// <param name="entity"></param>
		public void Create(Genre entity)
		{
			db.Genres.Add(entity);
		}
		/// <summary>
		/// чтение записи по индентификатору
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns></returns>
		public Genre Read(int id)
		{
			return db.Genres.Where(x => x.Id == id).FirstOrDefault();
		}
		/// <summary>
		/// чтение записи по наименованию
		/// </summary>
		/// <param name="genreName">наименование</param>
		/// <returns></returns>
		public Genre Read(string genreName)
		{
			return db.Genres.Where(x => x.Name == genreName).FirstOrDefault();
		}
		/// <summary>
		/// чтение всех записей
		/// </summary>
		/// <returns></returns>
		public List<Genre> ReadAll()
		{
			return db.Genres.ToList();
		}
		/// <summary>
		/// изменение записи
		/// </summary>
		/// <param name="entity"></param>
		public void Update(Genre entity)
		{
			db.Update(entity);
		}
		/// <summary>
		/// удаление записи
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(Genre entity)
		{
			db.Genres.Remove(entity);
		}
	}
}
