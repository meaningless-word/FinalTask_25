using FinalTask.BLL.Exceptions;
using FinalTask.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
			Genre item = db.Genres.Where(x => x.Id == id).FirstOrDefault();
			if (item is null) throw new GenreNotFoundException();

			return item;
		}

		public Genre Read(string genreName)
		{
			Genre item = db.Genres.Where(x => x.Name.Contains(genreName)).FirstOrDefault();
			if (item is null) throw new GenreNotFoundException();

			return item;
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
