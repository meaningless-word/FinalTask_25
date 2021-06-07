using FinalTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.DAL.Repositories
{
	public class GenreRepository : IRepository<Genre>, IDisposable
	{
		private AppContext db;

		public GenreRepository()
		{
			db = new AppContext();
		}

		public void Create(Genre entity)
		{
			db.Genres.Add(entity);
			db.SaveChanges();
		}

		public Genre Read(int id)
		{
			return db.Genres.Where(x => x.Id == id).FirstOrDefault();
		}

		public Genre Read(string genreName)
		{
			return db.Genres.Where(x => x.Name == genreName).FirstOrDefault();
		}

		public List<Genre> ReadAll()
		{
			return db.Genres.ToList();
		}

		public void Update(int id, Genre entity)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			var item = Read(id);
			db.Genres.Remove(item);
			db.SaveChanges();
		}

		public void Dispose()
		{
			db.Dispose();
		}
	}
}
