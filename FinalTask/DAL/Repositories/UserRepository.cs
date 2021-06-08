using FinalTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	/// <summary>
	/// класс базовых функций для операций над сущностью "пользователи"
	/// </summary>
	public class UserRepository
	{
		private AppContext db;

		public UserRepository(AppContext db)
		{
			this.db = db;
		}
		/// <summary>
		/// создание
		/// </summary>
		/// <param name="entity"></param>
		public void Create(User entity)
		{
			db.Users.Add(entity);
		}
		/// <summary>
		/// чтение записи по идентификатору
		/// </summary>
		/// <param name="id">идентификатор</param>
		/// <returns></returns>
		public User Read(int id)
		{
			return db.Users.Include("ReadedBooks").Where(x => x.Id == id).FirstOrDefault();
		}
		/// <summary>
		/// чтение записи по имени и e-mail пользователя
		/// </summary>
		/// <param name="Name">имя</param>
		/// <param name="Email">e-mail</param>
		/// <returns></returns>
		public User Read(string Name, string Email)
		{
			return db.Users.Include("ReadedBooks").Where(x => x.Name == Name && x.Email == Email).FirstOrDefault();
		}
		/// <summary>
		/// чтение всех записей
		/// </summary>
		/// <returns></returns>
		public List<User> ReadAll()
		{
			return db.Users.Include("ReadedBooks").ToList();
		}
		/// <summary>
		/// изменение записи
		/// </summary>
		/// <param name="entity"></param>
		public void Update(User entity)
		{
			db.Users.Update(entity);
		}
		/// <summary>
		/// удаление записи
		/// </summary>
		/// <param name="entity"></param>
		public void Delete(User entity)
		{
			db.Users.Remove(entity);
		}
	}
}
