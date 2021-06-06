using FinalTask.BLL.Exceptions;
using FinalTask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	public class UserRepository : IRepository<User>, IDisposable
	{
		private AppContext db;

		public UserRepository()
		{
			db = new AppContext();
		}

		public void Create(User entity)
		{
			db.Users.Add(entity);
			db.SaveChanges();
		}

		public User Read(int id)
		{
			User item = db.Users.Include("ReadedBooks").Where(x => x.Id == id).FirstOrDefault();
			if (item is null) throw new UserNotFoundException();

			return item;
		}

		public User Read(string Name, string Email)
		{
			User item = db.Users.Include("ReadedBooks").Where(x => x.Name == Name && x.Email == Email).FirstOrDefault();
			if (item is null) throw new UserNotFoundException();

			return item;
		}

		public List<User> ReadAll()
		{
			return db.Users.Include("ReadedBooks").ToList();
		}

		public void Update(int id, User entity)
		{
			User item = Read(id);
			item.Name = entity.Name;
			item.Email = entity.Email;
			item.ReadedBooks = entity.ReadedBooks;
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
