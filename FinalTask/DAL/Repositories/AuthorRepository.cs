using FinalTask.BLL.Exceptions;
using FinalTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	public class AuthorRepository : IRepository<Author>, IDisposable
	{
		private AppContext db;

		public AuthorRepository()
		{
			db = new AppContext();
		}

		public void Create(Author entity)
		{
			db.Authors.Add(entity);
			db.SaveChanges();
		}

		public Author Read(int id)
		{
			Author item = db.Authors.Where(x => x.Id == id).FirstOrDefault();
			if (item is null) throw new AuthorNotFoundException();

			return item;
		}

		public List<Author> ReadAll()
		{
			return db.Authors.ToList();
		}

		public void Update(int id, Author entity)
		{
			throw new NotImplementedException();
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
